namespace ClassLib
{
    public class Hero
    {
        private string heroId;
        private string heroName;
        private string fracion;
        private int level;
        private string castleLocation;
        private int troops;
        private List<Units> units;

        public string HeroId { get { return heroId; } }
        public string HeroName { get {  return heroName; } }
        public string Fraction { get { return fracion; } }
        public int Level { get { return level; } }
        public string CastleLocation { get {  return castleLocation; } }
        public int Troops { get {  return troops; } }
        public List<Units> Units { get {  return units; } }

        public Hero(string HeroId, string HeroName, string Fraction, int Level, string CastleLocation, int Troops, List<Units> Units)
        {
            heroId = HeroId;
            heroName = HeroName;
            fracion = Fraction;
            level = Level;
            castleLocation = CastleLocation;
            troops = Troops;
            units = Units;
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}