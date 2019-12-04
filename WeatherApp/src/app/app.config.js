config.$inject = ['$stateProvider', '$urlRouterProvider'];
export default function config($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('WeatherApp/Weather');
    $stateProvider.state('WeatherApp', {
        url: "/WeatherApp",
        views: {
            "": {
                template: require("./partials/app.html")
            },
            "header@WeatherApp": {
                template: require('./partials/header.html')
            },
            "sidebar@WeatherApp": {
                template: require('./partials/sidebar.html')
            },
            "footer@WeatherApp": {
                template: require('./partials/footer.html')
            },
        }
    });
}