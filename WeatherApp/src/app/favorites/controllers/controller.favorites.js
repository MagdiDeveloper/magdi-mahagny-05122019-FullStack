favoritesCtrl.$inject = ['favoritesService'];
export default function favoritesCtrl(favoritesService) {
    let vm = this;
    vm.favoritesS = favoritesService;
    vm.favorites = new Array();
    vm.selectedCity = {};
    function getMyFavorites(){
        vm.favoritesS.getMyFavorites().then(function (response) {
            if (response.data.Data) {
                angular.forEach(response.data.Data, item => vm.favorites.push(item));
            }
        });
    };
    vm.getFavoriteWeather = function (selectedCity) {
        vm.favoritesS.getFavoriteWeather(selectedCity.CityKey).then(function (response) {
            if (response.data.Data) {
                if (response.data.Data) {
                    vm.selectedCity = response.data.Data;
                    vm.selectedCity.LocalizedName = selectedCity.LocalizedName;
                }
            }
        });
    };
    vm.onInit = function () {
        getMyFavorites();
    };
}