using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Spring.Objects.Factory;
using Spring.Proxy;


namespace Buscador.WCFServerWeb
{
    class ServiceProxyTypeBuilder : CompositionProxyTypeBuilder
    {
        #region Fields

        private static readonly MethodInfo GetObject =
            typeof(IObjectFactory).GetMethod("GetObject", new Type[] { typeof(string) });

        private static Hashtable s_serviceTypeCache = new Hashtable();

        private string targetName;
        private bool useServiceProxyTypeCache;

        
        protected FieldBuilder objectFactoryField;

        #endregion

        #region Constructor(s) / Destructor

        
        public ServiceProxyTypeBuilder(string targetName, Type targetType, bool useServiceProxyTypeCache)
            : this(targetName, targetType, targetName, useServiceProxyTypeCache)
        {
        }

      
        public ServiceProxyTypeBuilder(string targetName, Type targetType, string serviceTypeName, bool useServiceProxyTypeCache)
        {
            this.targetName = targetName;
            this.useServiceProxyTypeCache = useServiceProxyTypeCache;

            this.Name = serviceTypeName;
            this.TargetType = targetType;
        }

        #endregion

        #region Protected Methods

        
        public virtual Type BuildProxyType(IObjectFactory objectFactory)
        {
            Type proxyType = null;
            if (useServiceProxyTypeCache)
            {
                lock (s_serviceTypeCache)
                {
                    proxyType = (Type)s_serviceTypeCache[this.Name];
                    if (proxyType == null)
                    {
                        proxyType = BuildProxyType();
                        s_serviceTypeCache[this.Name] = proxyType;
                    }
                }
            }
            else
            {
                proxyType = BuildProxyType();
            }

            FieldInfo field = proxyType.GetField("__objectFactory", BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(proxyType, objectFactory);

            return proxyType;
        }

        
        protected override void ImplementConstructors(TypeBuilder builder)
        {
            MethodAttributes attributes = MethodAttributes.Public |
                MethodAttributes.HideBySig | MethodAttributes.SpecialName |
                MethodAttributes.RTSpecialName;

            ConstructorBuilder cb = builder.DefineConstructor(
                attributes, CallingConventions.Standard, Type.EmptyTypes);

            ILGenerator il = cb.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldsfld, objectFactoryField);
            il.Emit(OpCodes.Ldstr, targetName);
            il.EmitCall(OpCodes.Callvirt, GetObject, null);
            il.Emit(OpCodes.Stfld, targetInstance);

            il.Emit(OpCodes.Ret);
        }

        
        protected override TypeBuilder CreateTypeBuilder(string name, Type baseType)
        {
            TypeBuilder typeBuilder = DynamicProxyManager.CreateTypeBuilder(name, baseType);

            objectFactoryField = typeBuilder.DefineField("__objectFactory", typeof(IObjectFactory),
                FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.InitOnly);

            return typeBuilder;
        }

        #endregion
    }
}