using Microsoft.AspNetCore.Mvc;
using Agdata.Api.DTOs;
using System.Net;
using Agdata.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Agdata.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly Services.Interfaces.IGetProfile _getProfile;
        private readonly Services.Interfaces.ISaveProfile _saveProfile;

        public ProfileController(Services.Interfaces.IGetProfile getProfile, Services.Interfaces.ISaveProfile saveProfile)
        {
            _getProfile = getProfile;
            _saveProfile = saveProfile;
        }

        // GET: api/<ProfileController>
        [HttpGet]
        public async Task<DTOs.ProfileDTO> Get()
        {
            return await _getProfile.Execute();
        }

        // POST api/<ProfileController>
        [HttpPost]
        public async Task<DTOs.ProfileDTO> Post(DTOs.ProfileDTO profileDTO)
        {
            profileDTO = await _saveProfile.Execute(profileDTO);
            return profileDTO;
        }
    }
}
