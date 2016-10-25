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

.directive('recipes', function () {
    return {
        restrict: 'A',
        replace: 'true',
        templateUrl: '/app/components/recipe/recipes.html',
        controller: 'recipeCtrl'
    }
});


/*
    .directive('recipes', function () {
    return {
        restrict: 'A',
        replace: 'true',
        templateUrl: '/app/components/home/home.html',
        controller: 'homeCtrl'
    }
});

*/