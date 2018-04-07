using AmberAndGrain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Services
{
    public class BatchRepository
    {
        public bool Create(int recipeId, string cooker)
        {
            using (var db = createConnection())
            {
                db.Open();

                var createBatch = db.Execute(@"INSERT INTO Batches
                                                            (RecipeId
                                                            ,Cooker
                                                            )
                                                        VALUES
                                                            (@recipeId
                                                            ,@cooker
                                                            )", new {recipeId, cooker});

                return createBatch == 1;
            }
        }

        public Batch Get(int batchId)
        {
            using (var db = createConnection())
            {
                db.Open();

                var getSingleBatch = db.QueryFirst<Batch>("select * from batches where id = @batchId", batchId);

                return getSingleBatch;
            }
        }

        public bool Update(Batch batch)
        {
            using (var db = createConnection())
            {
                db.Open();

                var result = db.Execute(@"UPDATE Batches
                                                       SET 
	                                                       DateBarrelled = @dateBarrelled
                                                          ,NumberOfBarrels = @numberOfBottles
                                                          ,DateBottled = @dateBottled
                                                          ,NumberOfBottles = @numberOfBottles
                                                          ,Cooker = @cooker
                                                          ,PricePerBottle = @pricePerBottle
                                                          ,NumberOfBottlesLeft = @numberOfBottlesLeft
                                                          ,Status = @status
                                                       WHERE id = @id", batch);
                return result == 1;
            }
        }

        private SqlConnection createConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }
    }
}