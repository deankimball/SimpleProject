using Agdata.Api.DTOs;
using Agdata.Api.Services.Interfaces;
using Agdata.Infrastructure.Repositories;
using Agdata.Domain.Entities;

namespace Agdata.Api.Services
{
    public class GetProfile : Interfaces.IGetProfile
    {
        private readonly IRepository<Profile> _profileRepository;

        public GetProfile(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<ProfileDTO> Execute()
        {
            return new ProfileDTO(await _profileRepository.GetAsync());
        }
    }
}
