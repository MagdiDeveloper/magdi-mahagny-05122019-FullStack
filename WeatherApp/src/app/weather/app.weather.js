import config from './config.weather';
import weatherService from './services/service.weather';
import weatherCtrl from './controllers/controller.weather';
import './../core/app.core';
angular.module('app.weather',['app.core'])
    .config(config)
    .service('weatherService',weatherService)
    .controller('weatherCtrl',weatherCtrl);
