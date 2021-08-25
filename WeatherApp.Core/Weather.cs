namespace WeatherApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weather")]
    public partial class Weather
    {
        public int WeatherId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Temperature { get; set; }

        [Required]
        public double HowTemperatureFeel { get; set; }

        [Required]
        public double MinTemperature { get; set; }

        [Required]
        public double MaxTemperature { get; set; }

        [Required]
        public double Humidity { get; set; }
    }
}
