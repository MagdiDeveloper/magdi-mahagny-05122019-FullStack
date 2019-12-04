config.$inject = ['$stateProvider'];
export default function config($stateProvider) {
    $stateProvider.state('WeatherApp.Favorites', {
        url: '/Favorites',
        views: {
            "content": {
                template: require('./partials/index.html'),
                controller: 'favoritesCtrl',
                controllerAs: 'fCtrl'
            }
        }
    });
}