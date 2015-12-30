
var routerApp = angular.module('project-management', ['ui.bootstrap', 'ui.router']);
routerApp.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/dashboard');
    $stateProvider
        .state('dashboard', {
            url: '/dashboard',
            templateUrl: '/template/projects',
            controller: 'DashboardController'
        })
        .state('issues', {
            url: '/project/:id/issues',
            templateUrl: '/template/issues',
            controller: 'IssuesController'
        });
}]);