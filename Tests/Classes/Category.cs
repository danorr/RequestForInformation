using System;
using System.Collections.Generic;

namespace Classes {
    public class Category {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool CanListAuctions { get; set;}
        public bool CanListClassifieds { get; set; }
        public bool CanRelist { get; set; }
        public string LegalNotice { get; set; }
        public int DefaultDuration { get; set; }
        public List<int> AllowedDurations { get; set; }
        public Fees Fee { get; set; }
        public int FreePhotoCount { get; set; }
        public bool IsFreeToRelist { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<object> EmbeddedContentOptions { get; set; }
        public int MaximumTitleLength { get; set; }
        public int AreaOfBusiness { get; set; }
        public int DefaultRelistDuration { get; set; }
    }
}
