weatherService.$inject = ['dataService'];
export default function weatherService(dataService) {
    let vm = this;
    vm.query = "";
    vm.cityWeather = {};
    vm.searchCity = function () {
        return dataService.get('Cities', this.query+'/Search');
    };
    vm.getCityWeather = function (key) {
        return dataService.get('Weather', key + '/city');
    };
    let service = {
        searchCity: vm.searchCity,
        query: vm.query,
        cityWeather: vm.cityWeather,
        getCityWeather : vm.getCityWeather
    };
    return service;
}