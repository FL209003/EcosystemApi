using Domain.ValueObjects;

namespace DTOs
{
    public class GeoUbicationDTO
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set;}

        public GeoUbicationDTO() { }

        public GeoUbicationDTO(GeoUbication geo) {
            Latitude = geo.Latitude;
            Longitude = geo.Longitude;
        }
    }
}