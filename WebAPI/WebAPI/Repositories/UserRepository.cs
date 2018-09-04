using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private System.Data.IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public bool AddUser(User user)
        {
            int rowsAffected = this._db.Execute(@"INSERT Users([FirstName],[LastName],[Gender],[DateOfBirth],[ImageName]) values (@FirstName, @LastName, @Gender, @DateOfBirth, @ImageName)", new { FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender, DateOfBirth = user.DateOfBirth, ImageName = user.ImageName });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            return this._db.Query<User>("SELECT * FROM [Users]").ToList();
        }

        public void UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}