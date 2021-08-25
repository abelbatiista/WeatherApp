using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Data
{
    public partial class Weather
    {
        public int WeatherId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public double HowTemperatureFeel { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double Humidity { get; set; }
    }
}
