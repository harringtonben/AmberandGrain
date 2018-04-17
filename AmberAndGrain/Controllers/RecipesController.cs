using AmberAndGrain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmberAndGrain.Controllers
{
    [RoutePrefix("api/recipes")]
    public class RecipesController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage AddRecipe(RecipesDto recipe)
        {
            var recipeRepository = new RecipeRepository();
            var createRecipe = recipeRepository.Create(recipe);

            if (createRecipe)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Sorry we could not create a recipe at this time, please try again later.");
        }

        [HttpGet, Route("")]
        public HttpResponseMessage GetAllRecipes()
        {
            var recipeRepository = new RecipeRepository();
            var getRecipes = recipeRepository.Get();

            return Request.CreateResponse(HttpStatusCode.OK, getRecipes);
        }

    }
}
