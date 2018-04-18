using AmberAndGrain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmberAndGrain.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var recipeRepository = new RecipeRepository();
            var recipes = recipeRepository.GetAll();

            return View(recipes);
        }

        //Get: Recipe/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Post: Recipe/Create
        [HttpPost]
        public ActionResult Create(RecipesDto recipe)
        {
            //save it to the database
            var recipeRepository = new RecipeRepository();
            var createNew = recipeRepository.Create(recipe);

            return RedirectToAction("Index");
        }

        //Get: Recipe/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var repo = new RecipeRepository();
            var recipe = repo.Get(id);

            if (recipe == null)
                return HttpNotFound("The recipe you requested does not exist");

            return View(recipe);
        }

        [HttpPost]
        public ActionResult Edit(int id, RecipesDto recipe)
        {
            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            var repo = new RecipeRepository();
            repo.Update(recipe, id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var repo = new RecipeRepository();
            var recipe = repo.Get(id);

            return View(recipe);
        }
    }
}