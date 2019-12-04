import config from './app.config';
import './core/app.core';
import './weather/app.weather';
import './favorites/app.favorites';
angular.module('app', ['app.core','app.weather','app.favorites'])
    .config(config);


