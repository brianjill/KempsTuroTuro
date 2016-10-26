kempsApp.controller('recipeCtrl', ['$scope', '$http', 'recipeService',
    function ($scope, $http, recipeService) {
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

        $scope.addRecipe = function (recipeDetails) {
            console.log("adding....");

            recipeService.addRecipe(recipeDetails);
            $scope.saveMessage = "Recipe has been added successfully";

            setTimeout(function () {
                $scope.$apply(function () {
                    $scope.enableRecipeDetails = false;
                });
            },
                1000);
        };

        $scope.saveRecipe = function(recipeDetails) {
            
            recipeService.saveRecipe(recipeDetails);
            $scope.saveMessage = "Recipe has been updated successfully";

            setTimeout(function() {
                    $scope.$apply(function() {
                        $scope.enableRecipeDetails = false;
                    });
                },
                1000);

        };
    }
]);