namespace NefitEasy.Models
{
    public class Location
    {
        public double Latitude { get; }

        public double Longitude { get; }

        internal Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
