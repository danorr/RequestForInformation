using System;
using System.Collections.Generic;

namespace Classes {
    public class Fees {
    public double Bundle { get; set; }
    public double EndDate { get; set; }
    public double Feature { get; set; }
    public double Gallery { get; set; }
    public double Listing { get; set; }
    public double Research { get; set; }
    public double Subtitle { get; set; }
    public double TenDays { get; set; }
    public List<ListingFeeTier> ListingFeeTier { get; set; }
    public double SecondCategory { get; set; }
}
}