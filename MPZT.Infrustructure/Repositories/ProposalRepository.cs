using Dapper;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Repositories
{
    public class ProposalRepository : IProposalRepository
    {

        public IList<Proposal> GetProposals(int id)
        {
            IList<Proposal> list = new List<Proposal>();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM Proposals AS P INNER JOIN Users AS U ON P.UserId = U.Id INNER JOIN AreaMPZT AS A ON P.AreaMPZTId = A.Id WHERE AreaMPZTId = {id}";
                db.Open();
                list = db.Query<Proposal, User, AreaMPZT, Proposal>(sql,
                    (proposal, user, area) =>
                    {
                        proposal.User = user;
                        proposal.AreaMPZT = area;
                        return proposal;
                    }

                    ).ToList();
            }
            return list;
        }

        public bool AddLikes(int id)
        {
            return AddOneIfValuesNotNull(id, "Likes");
        }

        public bool AddDislikes(int id)
        {
            return AddOneIfValuesNotNull(id, "Dislikes");
        }

        private bool AddOneIfValuesNotNull(int id, string columnName)
        {
            bool isSuccess = false;

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM Proposals WHERE  Id = {id}";
                string command;
                var proposal = db.Query<Proposal>(sql).Single();
                if (!((int)proposal[columnName] >= 1))
                    command = $"UPDATE Proposals SET {columnName} = 1 WHERE Id = {id}";
                else
                    command = $"UPDATE Proposals SET {columnName} = {columnName} + 1 WHERE Id = {id}";
                db.Open();
                var affectedRows = db.Execute(command);
                if (affectedRows >= 1)
                    isSuccess = true;
            }
            return isSuccess;
        }

        public Proposal Get(int id)
        {
            Proposal proposal = new Proposal();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM Proposals AS P INNER JOIN Users AS U ON P.UserId = U.Id INNER JOIN AreaMPZT AS A ON P.AreaMPZTId = A.Id WHERE P.Id = {id}";
                db.Open();
                proposal = db.Query<Proposal, User, AreaMPZT, Proposal>(sql,
                    (proposalObj, user, area) =>
                    {
                        proposalObj.User = user;
                        proposalObj.AreaMPZT = area;
                        return proposalObj;
                    }).Single();
            }
            return proposal;
        }

        #region not implemeted


        public IList<Proposal> GetAll()
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdate(Proposal item)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                if (item.Id > 0)
                    return Update(item, db);
                else
                    return Insert(item, db);
            }
        }

        private int Insert(Proposal item, IDbConnection db)
        {
            string sql = @"INSERT INTO Proposals (Description, UserId, AreaMPZTId) values "
                + $" ('{item.Description}',{item.User.Id},{item.AreaMPZT.Id});"
                + @" SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql).Single();
        
            return id;
        }

        private int Update(Proposal item, IDbConnection db)
        {

            string sql = $"UPDATE Proposal SET Description = {item.Description}" +
                $"WHERE Id = {item.Id};";

            var affectedRows = db.Execute(sql);
            return affectedRows;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

       

        #endregion
    }
}
