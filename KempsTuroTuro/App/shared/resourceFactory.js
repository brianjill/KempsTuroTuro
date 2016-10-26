'use strict';

var baseUrl = '//localhost:7820';

kempsApp.factory('recipeService', ['$resource',
    function ($resource) {
        var recipe = $resource(baseUrl + '/recipe', null,
            {
                getRecipe: {
                    url: baseUrl + '/recipe/:id',
                    method: 'GET',
                    isArray: false,
                    params: { id: '@id' }
                }
            });

        var getAllRecipes = function () {
            
            return recipe.query();
        }

        var getRecipeDetails = function (recipeId) {
            
            var recipeDetails = recipe.getRecipe({ id: recipeId });
            return recipeDetails;
        }

        return {
            getAllRecipes: getAllRecipes,
            getRecipeDetails: getRecipeDetails
        }
    }
]);