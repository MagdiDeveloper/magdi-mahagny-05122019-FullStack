import dataService from './services/dataService';
import cityWeather from './directives/directive.cityweather';
angular
    .module('app.core', ['ui.router'])
    .service('dataService', dataService)
    .directive('cityWeather', cityWeather);