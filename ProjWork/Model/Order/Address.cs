namespace ProjWork.Model.Order
{
    public class Address
    {
        public Address()
        {
        }
        public Address(string flatHouseNo, 
            string areaSector, string landMark, 
            int pincode, string city, string state)
        {
            FlatHouseNo = flatHouseNo;
            AreaSector = areaSector;
            LandMark = landMark;
            Pincode = pincode;
            City = city;
            State = state;
        }

        public string FlatHouseNo { get; set; }
        public string AreaSector {  get; set; }
        public string LandMark { get; set; }
        public int Pincode { get; set; }
        public string City {  get; set; }
        public string State { get; set; }
    }
}
