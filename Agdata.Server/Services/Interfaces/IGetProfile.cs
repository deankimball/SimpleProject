namespace Agdata.Api.Services.Interfaces
{
    public interface IGetProfile
    {
        Task<DTOs.ProfileDTO> Execute();
    }
}
