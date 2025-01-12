using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Payment_Calculator.Service
{
    public class AuthService
    {
        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(2000);
            return false;
        }
    }
}
