using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Payment_Calculator.Model
{
    [Table("debt")]
    public class DebtPayment
    {
        [PrimaryKeyAttribute, AutoIncrement]
        public int Id { get; set; }

        public string Lender { get; set; }

        public string OriginalAmount { get; set; }
               
        public string CurrentAmount { get; set; }
        public string Payment { get; set; }
               
        public string PercentageRate { get; set; }
    }
}
