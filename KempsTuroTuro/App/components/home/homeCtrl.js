kempsApp.controller('homeCtrl', ['$scope','$http', 'recipeService', function ($scope, $http, recipeService) {

        
    $scope.first = "Mabuhay";
    /*
        recipeService.getAllRecipes().$promise.then(
            function(result) {
                $scope.recipeList = result;
            }
            );
      */      
   
        /*
        recipeService.getAllRecipes().$promise.then(
            function(data) {
                console.log(data);
                $scope.recipeList = data;
            });
            */
    }
])
.directive('recipe', function () {
    return {
        restrict: 'A',
        replace: 'true',
        templateUrl: '/app/components/recipe/recipe.html',
        controller: 'recipeCtrl'
    }
})
.directive('recipes', function () {
    return {
        restrict: 'A',
        replace: 'true',
        templateUrl: '/app/components/recipe/recipes.html',
        controller: 'recipeCtrl'
    }
});
