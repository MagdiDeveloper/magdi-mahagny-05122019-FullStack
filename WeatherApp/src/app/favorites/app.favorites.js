import config from './config.favorites';
import favoritesService from './services/service.favorites';
import favoritesCtrl from './controllers/controller.favorites';
import './../core/app.core';
angular.module('app.favorites', ['app.core'])
    .config(config)
    .service('favoritesService', favoritesService)
    .controller('favoritesCtrl', favoritesCtrl);
