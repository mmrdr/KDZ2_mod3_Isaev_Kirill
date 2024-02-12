namespace ClassLib
{
    public class Units
    {
        private string unitName;
        private int quantity;
        private int experience;
        private string currentLocation;

        public string UnitName { get { return unitName; } }
        public int Quantity { get { return quantity; } }
        public int Experience { get {  return experience; } }
        public string CurrentLocation { get { return currentLocation; } }


        public Units(string UnitName, int Quantity, int Experience, string CurrentLocation)
        {
            currentLocation = CurrentLocation;
            unitName = UnitName;
            quantity = Quantity;
            experience = Experience;
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}
