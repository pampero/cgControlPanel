using System;
using System.Collections.Generic;
using SolrNet.Attributes;

namespace Buscador.Domain.com.clarin.entities
{
    public class SegmentCatalogInfo
    {
        [SolrField("Id")]
        public virtual int Id { get; set; }

        [SolrUniqueKey("SegmentCatalogInfo_id")]
        public virtual int SegmentCatalogInfoId { get; set; }
        [SolrField("Description")]
        public virtual string Description { get; set; }
        [SolrField("ExpertReview")]
        public virtual string ExpertReview { get; set; }
        [SolrField("LinkToVideo")]
        public virtual string LinkToVideo { get; set; }
        [SolrField("Model_id")]
        public virtual int ModelId { get; set; }
        [SolrField("ModelDescription")]
        public virtual string ModelDescription { get; set; }
        [SolrField("Brand_id")]
        public virtual int BrandId { get; set; }
        [SolrField("BrandDescription")]
        public virtual string BrandDescription { get; set; }
        [SolrField("Segment_id")]
        public virtual int SegmentId { get; set; }
        [SolrField("SegmentDescription")]
        public virtual string SegmentDescription { get; set; }
        [SolrField("PriceFrom")]
        public virtual double PriceFrom { get; set; }
        [SolrField("PriceTo")]
        public virtual double PriceTo { get; set; }
        [SolrField("RankingConfort")]
        public virtual int RankingConfort { get; set; }
        [SolrField("RankingDesign")]
        public virtual int RankingDesign { get; set; }
        [SolrField("RankingPrice")]
        public virtual int RankingPrice { get; set; }
        [SolrField("RankingSecurity")]
        public virtual int RankingSecurity { get; set; }
        [SolrField("UploadedPhotosQuantity")]
        public virtual int UploadedPhotosQuantity { get; set; }

        private IList<string> _positives;
        [SolrField("Positives")]
        public virtual IList<string> Positives
        {
            get
            {
                if (_positives == null)
                    _positives = new List<string>();
                return _positives;
            }
            set { _positives = value; }
        }

        private IList<string> _negatives;
        [SolrField("Negatives")]
        public virtual IList<string> Negatives
        {
            get
            {
                if (_negatives == null)
                    _negatives = new List<string>();
                return _negatives;
            }
            set { _negatives = value; }
        }

        private IList<string> _colours;
        [SolrField("CatalogColours")]
        public virtual IList<string> Colours
        {
            get
            {
                if (_colours == null)
                    _colours = new List<string>();
                return _colours;
            }
            set { _colours = value; }
        }
        public virtual double AverageRanking
        {
            get
            {
                int totalRanking = RankingConfort + RankingDesign + RankingPrice + RankingSecurity;

                decimal aux = Decimal.Divide(totalRanking, 4);

                float a = float.Parse((aux).ToString());
                int integerPart = int.Parse(Math.Floor(a).ToString());
                float decimalPart = a - integerPart;

                double result = 0;

                if (decimalPart < 0.25)
                    result = integerPart;

                if (decimalPart >= 0.25 && decimalPart < 0.75)
                    result = integerPart + 0.5;

                if (decimalPart >= 0.75)
                    result = integerPart + 1;

                return result;
            }

        }

        public virtual string TechnicalMeasureImage { get; set; }

    }
}
