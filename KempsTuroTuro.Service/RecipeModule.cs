using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KempsTuroTuro.Data.Interface;
using Nancy;

namespace KempsTuroTuro.Service
{
    public class RecipeModule : NancyModule
    {
        public RecipeModule(IRecipeService recipeService)
        {
            
            Get["/recipe"] = parameters => recipeService.GetRecipes();
            Get["/recipe/{id}"] = parameters => recipeService.GetRecipeDetails(parameters.id);
        }
    }
}