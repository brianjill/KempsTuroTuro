kempsApp.controller('recipeCtrl', ['$scope', '$http', 'recipeService', '$timeout',
    function ($scope, $http, recipeService, $timeout) {
        $scope.enableRecipeDetails = false;
        
        recipeService.getAllRecipes()
            .$promise.then(
                function(result) {
                    $scope.recipeList = result;
                }
            );
        $scope.editRecipe = function(recipe) {
            recipeService.getRecipeDetails(recipe.Id)
                .$promise.then(
                    function(result) {
                        $scope.recipeDetails = result;

                        setTimeout(function () {
                            $scope.$apply(function () {
                                $scope.enableRecipeDetails = true;
                            });
                        }, 1000);
                        
                        
                    }
                );
        };

        $scope.addRecipe = function(recipe) {

        };

        $scope.saveRecipe = function (recipeDetails) {

        };
    }
]);