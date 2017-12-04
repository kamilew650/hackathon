using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaportHelper.Token
{
    public static class TokenGenerator
    {
        public static string GenerateToken()
        {
            Guid g = Guid.NewGuid();
            return g.ToString();
        }
    }
}
