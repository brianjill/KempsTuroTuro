kempsApp.controller('recipeCtrl', ['$scope', '$http', 'recipeService', '$routeParams', function ($scope, $http, recipeService, $routeParams) {

        recipeService.getAllRecipes()
            .$promise.then(
                function(result) {
                    $scope.recipeList = result;
                }
            );
        $scope.editRecipe = function (recipe) {
            recipeService.getRecipeDetails(recipe.Id)
           .$promise.then(
               function (result) {
                   console.log(recipe.Id);
                   $scope.recipeDetails = result;

               }
           );
        };
        
        $scope.addRecipe = function(recipe) {
            
        };
        
    
        $scope.enableRecipeEdit = function() {
            if ($scope.recipeDetails !== undefined) return false;
            return true;
        }
        

    }
]);