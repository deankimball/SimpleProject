namespace Agdata.Api.DTOs
{
    public class ProfileDTO
    {
        public ProfileDTO() { } 

        public ProfileDTO(Domain.Entities.Profile profile)
        {
            this.Name = profile.Name;
            this.Address = profile.Address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public Domain.Entities.Profile GetProfile()
        {
            return new Domain.Entities.Profile { Name = this.Name, Address = this.Address };
        }
    }
}
