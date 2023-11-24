using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace vaseApi.Models {
    public enum Condition {
        Null,
        Perfect,
        Shabby,
        Average,
        Worn,
        NeedsRepair,
        Count
    }
    public class Vase {
        public int       Id              { get; set; }
        public string?   Name            { get; set; } = "";
        public string?   Commentary      { get; set; } = "";
        public DateTime  LastWatering    { get; set; }
        public double    WateredLevel    { get; set; }
        public DateTime  LastFertilizing { get; set; }
        public double    FertilizedLevel { get; set; }
        public double    LightingLevel   { get; set; }

        public bool   Autowatering { get; set; }
        public double WateringIntensity { get; set; }
        public bool   Autofertilizeing { get; set; }
        public double FertilizingIntensity { get; set; }
        public bool   IsLightingToggled { get; set; }
        public double LightingIntensity { get; set; }
        public double GlassOpacity { get; set; }

        public int       MainColorId { get; set; }
        public Color?    MainColor { get; set; }
        public int       SideColorId { get; set; }
        public Color?    SideColor { get; set; }
        public int       FlowerGenusId { get; set; }
        public Genus?    FlowerGenus { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Condition VaseCondition { get; set; }
        public double    VaseWeight { get; set; }
        public DateTime  LastRepairDate { get; set; }
        public DateTime  MountingDate { get; set; }
    }
}
