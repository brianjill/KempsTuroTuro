using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using KempsTuroTuro.Data.Domain;
using KempsTuroTuro.Data.Interface;
using KempsTuroTuro.Data.Repository;
using KempsTuroTuro.Service.Model;
using Newtonsoft.Json;

namespace KempsTuroTuro.Service
{
    public interface IRecipeService
    {
        string GetRecipeDetails(int id);
        string GetRecipes();
        void Save(RecipeDetailsVm recipeDetails);
    }

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;


        public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
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

        public void Save(RecipeDetailsVm recipeDetails)
        {
            var recipe = _recipeRepository.GetById(recipeDetails.Id);

            recipe.Description = recipeDetails.Description;
            recipe.Item.Name = recipeDetails.Name;
            recipe.StatusCode = (RecipeStatus)Enum.Parse(typeof(RecipeStatus), recipeDetails.Status); 
            
            _recipeRepository.Update(recipe);
            _unitOfWork.SaveChanges();
        }
    }

    
}