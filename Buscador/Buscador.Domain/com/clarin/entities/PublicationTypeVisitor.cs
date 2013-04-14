using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Buscador.Domain.com.clarin.entities
{
    public interface IPublicationTypeVisitor
    {
        void Visit(PublicationPremiumType publicationType);
        void Visit(PublicationBasicType publicationType);
        void Visit(PublicationSimpleType publicationType);
        void Visit(PublicationPremium45HighlighDaysType publicationType);
        void Visit(PublicationSuperPremiumType publicationType);
        void Visit(PublicationHighlightedType publicationType);
        void Visit(PublicationSuperHighlightedType publicationType);
        void Visit(PublicationLinealType publicationType);
    }

    public class PublicationTypeVisitor : IPublicationTypeVisitor
    {
        private HtmlHelper<object> _html;
        private Publication _publication;

        public PublicationTypeVisitor(Publication publication, HtmlHelper<object> html)
        {
            _publication = publication;
            _html = html;
        }

        public void Visit(PublicationPremiumType publicationType)
        {
            RenderPartialExtensions.RenderPartial(_html, "PublicationBasicSection", _publication);
        }

        public void Visit(PublicationBasicType publicationBasicType)
        {
            RenderPartialExtensions.RenderPartial(_html, "PublicationBasicSection", _publication);    
        }

        public void Visit(PublicationSimpleType publicationSimpleType)
        {
            RenderPartialExtensions.RenderPartial(_html, "PublicationSimpleSection", _publication);    
        }

        public void Visit(PublicationPremium45HighlighDaysType publicationType)
        {
            RenderPartialExtensions.RenderPartial(_html, "PublicationBasicSection", _publication);    
        }

        public void Visit(PublicationSuperPremiumType publicationType)
        {
            RenderPartialExtensions.RenderPartial(_html, "PublicationPremiumSection", _publication);
        }

        public void Visit(PublicationHighlightedType publicationType)
        {
            RenderPartialExtensions.RenderPartial(_html, "PublicationSimpleSection", _publication);        
        }

        public void Visit(PublicationSuperHighlightedType publicationType)
        {
            RenderPartialExtensions.RenderPartial(_html, "PublicationSimpleSection", _publication);        
        }
        public void Visit(PublicationLinealType publicationType)
        {
            RenderPartialExtensions.RenderPartial(_html, "PublicationLinealSection", _publication);
        }
    }
}