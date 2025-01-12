using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Payment_Calculator.Model
{
    public class User
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string ConfirmEmail { get; set; } = string.Empty;

        public string Username { get; set; }

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

    }
}
