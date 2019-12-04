dataService.$inject = ['$http'];
export default function dataService($http) {
    var vm = this;
    let urlBase = '/api';
    vm.get = function (controller, action, paramsObj) {
        return $http({
            url: apiBaseUrl + '/' + controller + '/' + action,
            method: 'GET',
            headers: {  
                'Content-Type': 'application/json'
            },
            params: paramsObj
        });
    };
    vm.post = function (controller, action, dataObj) {
        return $http({
            url: apiBaseUrl + '/' + controller + '/' + action,
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            data: dataObj
        });
    };
    vm.delete = function (controller, action, dataObj) {
        return $http({
            url: apiBaseUrl + '/' + controller + '/' + action,
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            data: paramsObj
        });
    };
    var service = {
        get: vm.get,
        post: vm.post,
        delete: vm.delete
    };
    return service;

}