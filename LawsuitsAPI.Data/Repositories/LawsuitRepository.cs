using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawsuitsAPI.Model;
using Dapper;

namespace LawsuitsAPI.Data.Repositories
{
	public class LawsuitRepository : ILawsuitRepository
	{
        private MySQLConfiguration _connectionString;

		public LawsuitRepository(MySQLConfiguration connectionString)
		{
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Lawsuit>> GetAllLawsuits()
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, caseTitle, number, courtId
                        FROM lawsuit";

            return await db.QueryAsync<Lawsuit>(sql, new { });
        }

        public async Task<Lawsuit> GetLawsuitDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, caseTitle, number, courtId
                        FROM lawsuit
                        WHERE id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Lawsuit>(sql, new { Id = id });
        }

        public async Task<bool> InsertLawsuit(Lawsuit lawsuit)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO lawsuit (caseTitle, number, courtId)
                        VALUES (@CaseTitle, @Number, @CourtId) ";

            var result = await db.ExecuteAsync(sql, new { lawsuit.CaseTitle, lawsuit.Number, lawsuit.CourtId });

            return result > 0;
        }

        public async Task<bool> UpdateLawsuit(Lawsuit lawsuit)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE lawsuit
                        SET caseTitle = @CaseTitle, number = @Number, courtId = @CourtId
                        WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new { lawsuit.CaseTitle, lawsuit.Number, lawsuit.CourtId, lawsuit.Id });

            return result > 0;
        }

        public async Task<bool> DeleteLawsuit(Lawsuit lawsuit)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE
                        FROM lawsuit
                        WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = lawsuit.Id });

            return result > 0;
        }
    }
}

