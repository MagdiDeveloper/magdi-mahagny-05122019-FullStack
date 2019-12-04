config.$inject = ['$stateProvider'];
export default function config($stateProvider) {
    $stateProvider.state('WeatherApp.Weather', {
        url: '/Weather',
        views: {
            "content": {
                template: require('./partials/index.html'),
                controller: 'weatherCtrl',
                controllerAs : 'wCtrl'
            }
        }
    });
}