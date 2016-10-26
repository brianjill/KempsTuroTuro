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
                },
                saveRecipe: {
                    url: baseUrl + '/recipe/:verb',
                    method: 'POST',
                    isArray: false,
                    params: { verb: "save" }
                },
                addRecipe: {
                    url: baseUrl + '/recipe/:verb',
                    method: 'POST',
                    isArray: false,
                    params: { verb: "add" }
                }
            });

        var getAllRecipes = function () {
            
            return recipe.query();
        }

        var getRecipeDetails = function (recipeId) {
            
            return recipe.getRecipe({ id: recipeId });
        }

        var saveRecipe = function(recipeDetails) {
            recipe.saveRecipe(recipeDetails);
        }

        var addRecipe = function (recipeDetails) {
            recipe.addRecipe(recipeDetails);
        }

        return {
            getAllRecipes: getAllRecipes,
            getRecipeDetails: getRecipeDetails,
            saveRecipe: saveRecipe,
            addRecipe: addRecipe
        }
    }
]);