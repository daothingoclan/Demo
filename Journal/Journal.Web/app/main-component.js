﻿(function(){
    'use strict';
    angular.module('tutorialWebApp').directive('airPair', airPair);

    function airPair(){
        var directive = {};
        directive.restrict = 'E';
        directive.templateUrl = 'index.html';
        return directive;
    };
})();