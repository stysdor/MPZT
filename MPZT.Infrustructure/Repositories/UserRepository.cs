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
                var sql = $"SELECT Password FROM Users WHERE UserName = {userName}";
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
                var sql = $"SELECT * FROM Users WHERE UserName = {userName}";
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
                var sql = $"SELECT * FROM Users AS U  INNER JOIN UserRoles AS UR ON U.Id = UR.IdUser INNER JOIN Roles AS R ON R.Id = UR.IdRole WHERE U.UserName = {userName}";
                db.Open();
                roles = db.Query<Role>(sql).ToList();
            }
            return roles;
        }
    }
 }

