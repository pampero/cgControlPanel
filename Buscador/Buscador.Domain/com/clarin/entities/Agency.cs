using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;

namespace Buscador.Domain.com.clarin.entities
{
    public class Agency
    {
        [SolrUniqueKey("agency_id")]
        public virtual string Id { get; set; }
        [SolrUniqueKey("agency_user_id")]
        public virtual int UserId { get; set; }
        [SolrUniqueKey("agency_name")]
        public virtual string Name { get; set; }
        [SolrUniqueKey("agency_logo_id")]
        public virtual int LogoId { get; set; }
        [SolrUniqueKey("agency_email")]
        public virtual string EMail { get; set; }
        [SolrUniqueKey("agency_website")]
        public virtual string Website { get; set; }

        private IList<string> _services { get; set; }
        [SolrUniqueKey("agency_services")]
        public virtual IList<string> Services
        {
            get
            {
                if (_services == null)
                    _services = new List<string>();
                return _services;
            }
            set { _services = value; }
        }

        [SolrUniqueKey("agency_phone_number")]
        public virtual string PhoneNumber { get; set; }
        [SolrUniqueKey("agency_pic_qty")]
        public virtual string PictureQuantity { get; set; }
        [SolrUniqueKey("agency_address")]
        public virtual string Address { get; set; }
        [SolrUniqueKey("agency_description")]
        public virtual string Description { get; set; }
        [SolrUniqueKey("agency_location_coordinates")]
        public string LocationCoordinates { get; set; }
    }
}
