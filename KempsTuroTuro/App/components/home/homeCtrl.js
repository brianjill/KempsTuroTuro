kempsApp.controller('homeCtrl', ['$scope', 'recipeService', function ($scope, recipeService) {

        console.log('here');
        $scope.first = "Mabuhay";
        recipeService.getAllRecipes().$promise.then(
            function(result) {

                $scope.recipeList = result;
            }
            );
        /*
        recipeService.getAllRecipes().$promise.then(
            function(data) {
                console.log(data);
                $scope.recipeList = data;
            });
            */
    }
]);
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