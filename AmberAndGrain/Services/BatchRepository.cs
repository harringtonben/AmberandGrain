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
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var createBatch = db.Execute(@"INSERT INTO Batches
                                                            (RecipeId
                                                            ,Cooker
                                                            )
                                                        VALUES
                                                            (@recipeId
                                                            ,@cooker
                                                            )", new { recipeId, cooker});

                return createBatch == 1;
            }
        }
    }
}