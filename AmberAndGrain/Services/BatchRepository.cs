using AmberAndGrain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Services
{
    public class BatchRepository
    {
        public bool Create(int recipeId, string cooker)
        {
            var db = new AppDbContext();
            var newBatch = db.Batches.Add(new Batch { RecipeId = recipeId, Cooker = cooker, DateCreated = DateTime.Now });
            db.SaveChanges();

            return newBatch.Id > 0;
            //using (var db = createConnection())
            //{
            //    db.Open();

            //    var createBatch = db.Execute(@"INSERT INTO Batches
            //                                                (RecipeId
            //                                                ,Cooker
            //                                                )
            //                                            VALUES
            //                                                (@recipeId
            //                                                ,@cooker
            //                                                )", new {recipeId, cooker});

            //    return createBatch == 1;
            //}
        }

        public Batch Get(int batchId)
        {
            var db = new AppDbContext();
            return db.Batches.Find(batchId);
            //using (var db = createConnection())
            //{
            //    db.Open();

            //    var getSingleBatch = db.QueryFirst<Batch>("select * from batches where id = @batchId", new { batchId });

            //    return getSingleBatch;
            //}
        }

        public bool Update(Batch batch)
        {

            var db = new AppDbContext();
            var updateBatch = db.Entry(batch).State = EntityState.Modified;

            //var existingBatch = db.Batches.Find(batch.Id);

            //existingBatch.DateBarrelled = batch.DateBarrelled;
            //existingBatch.DateBottled = batch.DateBottled;
            //existingBatch.NumberOfBarrels = batch.NumberOfBarrels;
            //existingBatch.NumberOfBottles = batch.NumberOfBottles;
            //existingBatch.NumberOfBottlesLeft = batch.NumberOfBottlesLeft;
            //existingBatch.PricePerBottle = batch.PricePerBottle;
            //existingBatch.Status = batch.Status;

            db.SaveChanges();

            return updateBatch > 0;
            //using (var db = createConnection())
            //{
            //    db.Open();

            //    var result = db.Execute(@"UPDATE Batches
            //                                           SET 
            //                                            DateBarrelled = @dateBarrelled
            //                                              ,NumberOfBarrels = @numberOfBottles
            //                                              ,DateBottled = @dateBottled
            //                                              ,NumberOfBottles = @numberOfBottles
            //                                              ,Cooker = @cooker
            //                                              ,PricePerBottle = @pricePerBottle
            //                                              ,NumberOfBottlesLeft = @numberOfBottlesLeft
            //                                              ,Status = @status
            //                                           WHERE id = @id", batch);
            //    return result == 1;
            //}
        }

        private SqlConnection createConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }
    }
}