using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLib
{
    public sealed class Hero
    {
        private string heroId;
        private string heroName;
        private string fracion;
        private int level;
        private string castleLocation;
        private int troops;
        private List<Units> units;

        [JsonPropertyName("hero_id")]
        public string HeroId { get { return heroId; } set { heroId = value; } }

        [JsonPropertyName("hero_name")]
        public string HeroName { get {  return heroName; } set { heroName = value; } }

        [JsonPropertyName("faction")]
        public string Fraction { get { return fracion; } set { fracion = value; } }

        [JsonPropertyName("level")]
        public int Level { get { return level; } set { level = value; } }

        [JsonPropertyName("castle_location")]
        public string CastleLocation { get { return castleLocation; } set { castleLocation = value; } }

        [JsonPropertyName("troops")]
        public int Troops { get {  return troops; } set { troops = value; } }

        [JsonPropertyName("units")]
        public List<Units> Units { get { return units; } set { units = value; } }

        public Hero(string HeroId, string HeroName, string Fraction, int Level, string CastleLocation, int Troops, List<Units> Units)
        {
            this.HeroId = HeroId;
            this.HeroName = HeroName;
            this.Fraction = Fraction;
            this.Level = Level;
            this.CastleLocation = CastleLocation;
            this.Troops = Troops;
            this.Units = Units;
        }

        public Hero()
        {
            Units = new List<Units>();
        }

        public string ToJson()
        {
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(this, jsonOptions);
        }
    }
}