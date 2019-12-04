weatherCtrl.$inject = ['weatherService'];
export default function weatherCtrl(weatherService) {
    let vm = this;
    vm.weatherS = weatherService;
    vm.cities = new Array();
    vm.searchCity = function () {
        vm.cities = new Array();
        vm.weatherS.searchCity().then(function (response) {
            if (response.data.Data) {
                angular.forEach(response.data.Data, item => vm.cities.push(item));
            }
        });
        vm.getCityWeather = function (selectedCity) {
            vm.weatherS.getCityWeather(selectedCity.Key).then(function (response) {
                if (response.data.Data) {
                    vm.weatherS.cityWeather = response.data.Data;
                    vm.weatherS.cityWeather.LocalizedName = selectedCity.LocalizedName;
                }
            });
        };
    };

}