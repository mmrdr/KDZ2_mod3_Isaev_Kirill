using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLib
{
    public class Units
    {
        private string unitName;
        private int quantity;
        private int experience;
        private string currentLocation;

        [JsonPropertyName("unit_name")]
        public string UnitName { get { return unitName; } set { unitName = value; } }

        [JsonPropertyName("quantity")]
        public int Quantity { get { return quantity; } set { quantity = value; } }

        [JsonPropertyName("experience")]
        public int Experience { get {  return experience; } set { experience = value; } }

        [JsonPropertyName("current_location")]
        public string CurrentLocation { get { return currentLocation; } set { currentLocation = value; } }


        public Units(string UnitName, int Quantity, int Experience, string CurrentLocation)
        {        
            this.UnitName = UnitName;
            this.Quantity = Quantity;
            this.Experience = Experience;
            this.CurrentLocation = CurrentLocation;
        }

        public Units() { }

        public string ToJson()
        {
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(this, jsonOptions);
        }
    }
}
