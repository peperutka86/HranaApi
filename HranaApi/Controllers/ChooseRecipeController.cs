using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HranaLibrary.Models;
using HranaLibrary.Services;
using HranaLibrary.Validation;





namespace HranaApi.Controllers
{
    public class RecipesController : ApiController
    {
        private readonly IRecipeService1 service;

        public RecipesController(IRecipeService1 service)
        {
            this.service = service;
        }

        // GET: api/recipes
        public IEnumerable<Recipe> Get()
        {
            return service.GetRecipes();
        }

        // GET: api/recipes/5
        public IHttpActionResult Get(int id)
        {
            var recipe = service.GetRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // POST: api/recipes
        public HttpResponseMessage Post(Recipe recipe)
        {
            Recipe_Validation validator = new Recipe_Validation();
            var result = validator.Validate(recipe);

            if (!result.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (service.AddRecipe(recipe))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }


        // PUT: api/recipes/5
        public IHttpActionResult Put(int id, Recipe recipe)
        {
            Recipe_Validation validator = new Recipe_Validation();
            var result = validator.Validate(recipe);

            if (!result.IsValid) return BadRequest();

            try
            {
                if (service.UpdateRecipe(id, recipe))
                {
                    return Ok();
                }

                return InternalServerError();
            }
            catch (ApplicationException ex)
            {
                return NotFound();
            }
        }

    }
    }

