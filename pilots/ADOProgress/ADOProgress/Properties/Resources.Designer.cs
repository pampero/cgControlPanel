﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADOProgress.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ADOProgress.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS ( SELECT 1 FROM sys.objects WHERE name = &apos;AdoProcess_Test1&apos; )
        ///BEGIN
        ///	DROP PROCEDURE AdoProcess_Test1
        ///END
        ///go
        ///
        ///CREATE PROCEDURE AdoProcess_Test1
        ///AS
        ///BEGIN
        ///	SET NOCOUNT ON -- Used for performance and making sure we don&apos;t send back unneeded information.
        ///	DECLARE @time VARCHAR(16)
        ///	WAITFOR DELAY &apos;00:00:03&apos;	
        ///	
        ///	SET @time = CONVERT(VARCHAR(16),GETDATE(),114)
        ///	PRINT &apos;Completed  25% - Testing 1 Raised At &apos;  + @time
        ///	WAITFOR DELAY &apos;00:00:03&apos;
        ///	SET @time = CONVERT(VARCHAR(16),GETDATE(),114)
        ///	P [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AdoProgressProcedure {
            get {
                return ResourceManager.GetString("AdoProgressProcedure", resourceCulture);
            }
        }
    }
}