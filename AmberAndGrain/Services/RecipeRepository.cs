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
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
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



        public RecipesDto Get(int id)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var result = db.QueryFirst<RecipesDto>("select * from recipes where id = @id", new { id });

                return result;
            }
        }

        public List<RecipesDto> GetAll()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var result = db.Query<RecipesDto>("select * from recipes").ToList();

                return result;
            }
        }

        public bool Update(RecipesDto recipe, int id)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var createRecipe = db.Execute(@"update Recipes
                                                            set Name = @Name
                                                            ,PercentWheat = @PercentWheat
                                                            ,PercentCorn = @PercentCorn
                                                            ,BarrelAge = @BarrelAge
                                                            ,BarrelMaterial = @BarrelMaterial
                                                            ,Creator = @Creator
                                                            where id = @id", new
                                                                                {
                                                                                    recipe.Name,
                                                                                    recipe.PercentWheat,
                                                                                    recipe.PercentCorn,
                                                                                    recipe.BarrelAge,
                                                                                    recipe.BarrelMaterial,
                                                                                    recipe.Creator,
                                                                                    id
                                                                                });

                return createRecipe == 1;
            }
        }
    }
}