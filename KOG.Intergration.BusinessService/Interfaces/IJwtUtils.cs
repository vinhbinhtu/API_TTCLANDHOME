using KOG.Intergration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOG.Intergration.BusinessService.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UserModel user);

        public UserModel ValidateJwtToken(string token);
    }
}
