using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using System.IO;
using SQLite;
using Debt_Payment_Calculator.Model;


namespace Debt_Payment_Calculator.Service
{
    public class DatabaseService
    {
        private const string DB_NAME = "db";
        private readonly SQLiteAsyncConnection _conn;

        public DatabaseService()
        {
            _conn = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _conn.CreateTableAsync<DebtPayment>();
        }

        public async Task<List<DebtPayment>> GetDebtPayments()
        {
            return await _conn.Table<DebtPayment>().ToListAsync();
        }

        public async Task<DebtPayment> GetById(int id)
        {
            return await _conn.Table<DebtPayment>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(DebtPayment debtpayment)
        {
            await _conn.InsertAsync(debtpayment);
        }

        public async Task Update(DebtPayment debtpayment)
        {
            await _conn.UpdateAsync(debtpayment);
        }

        public async Task Delete(DebtPayment debtpayment)
        {
            await _conn.DeleteAsync(debtpayment);
        }
    }
}
