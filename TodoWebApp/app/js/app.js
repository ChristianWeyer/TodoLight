var TodoApp = angular.module("TodoApp", ["ngResource"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: ListController, templateUrl: 'list.html' }).
            when('/new', { controller: CreateController, templateUrl: 'detail.html' }).
            when('/edit/:itemId', { controller: EditController, templateUrl: 'detail.html' }).
            otherwise({ redirectTo: '/' });
    });

TodoApp.factory('Todo', function ($resource, $http) {
    return $resource('../../api/todos/:id', { id: '@id' }, { update: { method: 'PUT' } });
});