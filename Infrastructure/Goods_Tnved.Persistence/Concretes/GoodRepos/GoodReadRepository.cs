using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goods_Tnved.Application.Repositories.GoodRepos;
using Goods_Tnved.Domain.Entities;
using Dapper;
using System.Data.SqlClient;

namespace Goods_Tnved.Persistence.Concretes.GoodRepos
{
    public class GoodReadRepository : IGoodReadRepository
    {
        readonly string _connectionString = "Server=DESKTOP-CJBAJUG\\SQLEXPRESS; Database=goods_tnved_db; Trusted_Connection=true; Encrypt=False;";


        private IEnumerable<Good> MakeSchema(IEnumerable<Good> goods)
        {
            var lookup = goods.ToLookup(g => g.PARENT_ID);
            foreach (var good in goods)
            {
                good.Children = lookup[good.ID].ToList();
            }
            return goods;
        }

        public async Task<Good> GetGoodAsync(string GoodCode)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                string query = @"
            WITH RecursiveCTE AS (
                SELECT ID, CODE, NAME, PARENT_ID
                FROM Goods
                WHERE CODE = @GoodCode
                UNION ALL
                SELECT g.ID, g.CODE, g.NAME, g.PARENT_ID
                FROM Goods g
                INNER JOIN RecursiveCTE r ON g.PARENT_ID = r.ID
            )
            SELECT ID, CODE, NAME, PARENT_ID
            FROM RecursiveCTE;";

                var goods = await connection.QueryAsync<Good>(query, new { GoodCode });
                var hierarchy = MakeSchema(goods);
                return hierarchy.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        
    }
}
   

    
    
   

    




