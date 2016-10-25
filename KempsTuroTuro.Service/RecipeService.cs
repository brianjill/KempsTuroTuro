using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using KempsTuroTuro.Data.Domain;
using KempsTuroTuro.Data.Repository;
using KempsTuroTuro.Service.Model;
using Newtonsoft.Json;

namespace KempsTuroTuro.Service
{
    public interface IRecipeService
    {
        string GetRecipeDetails(int id);
        string GetRecipes();
    }

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public string GetRecipeDetails(int id)
        {
            
            var recipe = _recipeRepository.GetById(id);

            var recipeDetails = new RecipeDetailsVm
            {
                Description = recipe.Description,
                Status = recipe.StatusCode.ToString(),
                Id = recipe.Id,
                Name = recipe.Item.Name
            };


            return JsonConvert.SerializeObject(recipeDetails);
        }

        public string GetRecipes()
        {
            var recipes = _recipeRepository.GetAll();

            var recipesVm = new List<RecipeIntroVm>();

            foreach (var recipe in recipes)
            {
                recipesVm.Add(new RecipeIntroVm
                {
                    Id=recipe.Id,
                    Name = recipe.Item.Name
                });
            }

            return JsonConvert.SerializeObject(recipesVm);

        }
    }

    
}