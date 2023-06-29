using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Models
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
