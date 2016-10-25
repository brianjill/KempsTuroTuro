kempsApp.controller('recipeCtrl', ['$scope', '$http', 'recipeService', function ($scope, $http, recipeService) {

        recipeService.getAllRecipes()
            .$promise.then(
                function(result) {
                    $scope.recipeList = result;
                }
            );

    }
]);