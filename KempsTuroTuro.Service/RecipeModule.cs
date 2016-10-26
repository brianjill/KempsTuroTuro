using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KempsTuroTuro.Data.Interface;
using KempsTuroTuro.Service.Model;
using Nancy;
using Nancy.ModelBinding;

namespace KempsTuroTuro.Service
{
    public class RecipeModule : NancyModule
    {
        public RecipeModule(IRecipeService recipeService) :base("/recipe")
        {
            
            Get["/"] = parameters => recipeService.GetRecipes();

            Get["/{id}"] = parameters => recipeService.GetRecipeDetails(parameters.id);

            Post["/save"] = parameters =>
            {
                var post = this.Bind<RecipeDetailsVm>();
                recipeService.Save(post);
                return Response.AsJson(post);
            };

            Post["/add"] = parameters =>
            {
                var post = this.Bind<RecipeDetailsVm>();
                recipeService.Add(post);
                return Response.AsJson(post);
            };

            Delete[@"/{id})"] = parameters => recipeService.Delete(parameters.id);

        }
    }
}