using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace AAExpenseTracker.Models
{
    public class BudgetContext : DbContext
    {
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseTag> ExpenseTags { get; set; }
        public DbSet<FixExpen> FixExpens { get; set; }
        public DbSet<FixIncom> FixIncoms { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeTag> IncomeTags { get; set; }
        public DbSet<User> Users { get; set; }

        byte[] MakeSalt()
        {
            Random random = new Random();
            var saltBytes = new byte[random.Next(4, 8)];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetNonZeroBytes(saltBytes);
            return saltBytes;
        }

        public string ByteArrayToHexString(byte[] bytes)
        {
            return bytes.Select(b => b.ToString("x2")).Aggregate((s1, s2) => s1 + s2);
        }

        public byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length / 2)
                .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16)).ToArray();
        }

        string GetSaltedHash(string pwd, byte[] saltBytes)
        {
            var pwdBytes = Encoding.UTF8.GetBytes(pwd);
            var saltNpwdBytes = pwdBytes.Concat(saltBytes).ToArray();
            byte[] saltedHashBytes;
            using (var hashObj = new SHA512Managed())
                saltedHashBytes = hashObj.ComputeHash(saltNpwdBytes);
            var saltedHash = ByteArrayToHexString(saltedHashBytes);
            return saltedHash;
        }

        string GetSaltedHash(string pwd, string salt)
        {
            var saltBytes = HexStringToByteArray(salt);
            return GetSaltedHash(pwd, saltBytes);
        }

        public void AddUser(User usr, string pwd)
        {
            try
            {
                var saltBytes = MakeSalt();
                var salt = ByteArrayToHexString(saltBytes);
                var saltedHash = GetSaltedHash(pwd, saltBytes);
                usr.Salt = salt;
                usr.SaltedHash = saltedHash;
                Users.Add(usr);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Authenticate(string usr, string pwd)
        {
            try
            {
                var user = Users.Find(usr);
                if (user == null)
                    return false;
                var testSaltedHash = GetSaltedHash(pwd, user.Salt);
                return testSaltedHash == user.SaltedHash;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}