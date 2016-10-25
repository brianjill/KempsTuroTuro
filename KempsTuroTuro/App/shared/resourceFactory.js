'use strict';

var baseUrl = '//localhost:7820';

kempsApp.factory('recipeService', ['$resource',
    function ($resource) {
        var recipe = $resource(baseUrl + '/recipe', null,
            {
                getRecipe: {
                    url: baseUrl + '/recipe/:id',
                    method: 'GET',
                    isArray: true,
                    params: { id: '@id' }
                }
            });

        var getAllRecipes = function () {
            console.log('here');
            return recipe.query();
        }

        var getRecipeDetails = function(recipeId) {
            return recipe.getRecipe({id:recipeId});
        }

        return {
            getAllRecipes: getAllRecipes,
            getRecipeDetails: getRecipeDetails
        }
    }
]);