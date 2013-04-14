using System;

namespace Buscador.Domain.com.clarin.entities
{
    [Serializable]
    public abstract class PublicationType
    {
        public virtual int Id { get; set; }
        
        public virtual string Descripcion { get; set; }
        public virtual int EstadoDefaultPers { get; set; }
        public virtual int EstadoDefaultEmpr	 { get; set; }
        public virtual int DiasPublicacionE	 { get; set; }
        public virtual int DiasRenovacionE	 { get; set; }
        public virtual int DiasPublicacionP	 { get; set; }
        public virtual int DiasRenovacionP	 { get; set; }
        public virtual int CantFotos	 { get; set; }
        public virtual int CantVideos	 { get; set; }
        public virtual int Prioridad	 { get; set; }
        public virtual int PrecioPartPublicacion	 { get; set; }
        public virtual int PrecioPartRenovacion	 { get; set; }
        public virtual int Particulares	 { get; set; }
        public virtual int Empresas { get; set; }
        public virtual int Deautos	 { get; set; }
        public virtual int AutosClarin { get; set; }

        public abstract void Accept(IPublicationTypeVisitor publicationTypeVisitor);

        protected PublicationType()
        {
            
        }
    }
}