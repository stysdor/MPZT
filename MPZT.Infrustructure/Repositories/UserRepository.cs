using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPZT.Infrustructure.ModelDto;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace MPZT.Infrustructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool ValidateUser(string userName, string password)
        {
            bool isValidate = false;

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT Password FROM Users WHERE UserName = '{userName}'";
                db.Open();
                var pass = db.Query<string>(sql).SingleOrDefault();
                if (!(pass == null) && string.Equals(pass,password))
                {
                    isValidate = true;
                }
            }
            return isValidate;
        }

        public User GetUser(string userName)
        {
            User user = new User();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM Users WHERE UserName = '{userName}'";
                db.Open();
                user = db.Query<User>(sql).SingleOrDefault();
            }
            return user;
        }

        public IList<Role> GetRolesForUser(string userName)
        {
            IList<Role> roles = new List<Role>();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM Users AS U  INNER JOIN UserRoles AS UR ON U.Id = UR.IdUser INNER JOIN Roles AS R ON R.Id = UR.IdRole WHERE U.UserName = '{userName}'";
                db.Open();
                roles = db.Query<Role>(sql).ToList();
            }
            return roles;
        }

        public string GetUserNameByEmail(string email)
        {
            string userName;

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT UserName FROM Users WHERE Email = '{email}'";
                db.Open();
                userName = db.Query<string>(sql).SingleOrDefault();
            }
            return userName;
        }

        public int InsertUser(User item)
        {
            int id;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                string sql = @"INSERT INTO Users values "
               + $" ('{item.UserName}','{item.Password}','{item.Email}','{item.FirstName}','{item.LastName}', 0);"
               + @" SELECT CAST(SCOPE_IDENTITY() as int);";
                id = db.Query<int>(sql).Single();
            }
            return id;
        }

        public bool SetRoleForUser(int userId, string role)
        { 
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                var sql = $"SELECT Id FROM Roles WHERE Name = '{role}'";
                var sql2 = $"SELECT * From Users WHERE Id = {userId}";

                try
                {
                    var roleId = db.Query<int>(sql).SingleOrDefault();
                    var user = db.Query<User>(sql2).SingleOrDefault();
                    if (roleId > 0 && !(user == null))
                    {
                        var command = $"INSERT INTO UserRoles VALUES ({userId}, {roleId})";
                        var affectedRows = db.Execute(command);
                        if (affectedRows > 0)
                            return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public int GetOfficeId(int userId)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                string sql = $"SELECT O.Id FROM Offices AS O INNER JOIN OfficeMembers AS OM ON O.Id = OM.OfficeId INNER JOIN Users AS U ON U.Id = OM.UserId WHERE U.Id = {userId}";
                var id = db.Query<int>(sql).SingleOrDefault();
                return id;
            }
            
        }
    }
 }

