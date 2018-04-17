using AmberAndGrain.Controllers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Services
{
    public class RecipeRepository
    {
        public bool Create(RecipesDto recipe)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var createRecipe = db.Execute(@"INSERT INTO Recipes
                                                            (Name
                                                            ,PercentWheat
                                                            ,PercentCorn
                                                            ,BarrelAge
                                                            ,BarrelMaterial
                                                            ,Creator)
                                                        VALUES
                                                            (@Name
                                                            ,@PercentWheat
                                                            ,@PercentCorn
                                                            ,@BarrelAge
                                                            ,@BarrelMaterial
                                                            ,@Creator)", recipe);

                return createRecipe == 1;
            }
        }

        public List<RecipesDto> Get()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var recipes = db.Query<RecipesDto>("select * from recipes").ToList();

                return recipes;
            }

        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }
    }
}