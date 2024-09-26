using Agdata.Api.DTOs;
using Agdata.Domain.Entities;
using Agdata.Infrastructure.Repositories;

namespace Agdata.Api.Services
{
    public class SaveProfile : Interfaces.ISaveProfile
    {
        private readonly IRepository<Profile> _profileRepository;

        public SaveProfile(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public async Task<ProfileDTO> Execute(ProfileDTO profile)
        {
            await _profileRepository.SaveAsync(profile.GetProfile());
            return profile;
        }
    }
}
