favoritesService.$inject = ['dataService','weatherService'];
export default function favoritesService(dataService, weatherService) {
    let vm = this;
    vm.weatherS = weatherService;
    vm.getMyFavorites = function () {
        return dataService.get('Favorites', '');
    };
    vm.addToFavorite = function (cityWeather) {
        return dataService.post('Favorites', 'Insert', cityWeather);
    };
    vm.getFavoriteWeather = function (key) {
        return vm.weatherS.getCityWeather(key);
    };

    let service = {
        getMyFavorites: vm.getMyFavorites,
        getFavoriteWeather: vm.getFavoriteWeather,
        addToFavorite: vm.addToFavorite,
        removeFavorite : vm.removeFavorite
    };
    return service;
}