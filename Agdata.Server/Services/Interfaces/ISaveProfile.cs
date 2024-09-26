namespace Agdata.Api.Services.Interfaces
{
    public interface ISaveProfile
    {
        Task<DTOs.ProfileDTO> Execute(DTOs.ProfileDTO profile);
    }
}
