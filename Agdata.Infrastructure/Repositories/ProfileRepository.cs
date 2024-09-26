using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agdata.Domain;
using Entities = Agdata.Domain.Entities;

namespace Agdata.Infrastructure.Repositories
{
    public class ProfileRepository : IRepository<Entities.Profile>
    {
        public async Task<Entities.Profile> GetAsync()
        {
            return new Entities.Profile { Name = "Dean Kimball", Address = "3333 Madison Ave" };
        }

        public async Task SaveAsync(Entities.Profile entity)
        {
            //Persistence goes here
            return;
        }
    }
}
