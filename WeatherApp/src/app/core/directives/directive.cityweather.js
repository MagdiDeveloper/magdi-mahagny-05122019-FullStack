cityWeather.$inject = ['favoritesService'];
export default function cityWeather(favoritesService) {
    let directive = {
        restrict: 'E',
        template: require('./../templates/template.cityweather.html'),
        controller: cityWeatherCtrl,
        scope: {
            model: '='
        }

    };

    cityWeatherCtrl.$inject = ['$scope'];
    function cityWeatherCtrl($scope) {
        $scope.addToFavorite = function () {
            favoritesService.addToFavorite($scope.model).then(function (response) {
                if (response.data.Data) {
                    $scope.model.IsFavorite = true;
                    alert('Saved successfully!');
                } else {
                    alert(response.data.Message);
                }
            });
        };
        $scope.removeFromFavorite = function () {
            favoritesService.removeFromFavorite($scope.model).then(function (response) {
                if (response.data.Data) {
                    $scope.model.IsFavorite = false;
                    alert('Removed successfully!');
                } else {
                    alert(response.data.Message);
                }
            });
        };

    }
   
    return directive;

}