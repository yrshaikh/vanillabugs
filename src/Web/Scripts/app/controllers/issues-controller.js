angular.module('project-management').controller('IssuesController',
	['$scope', '$http', '$stateParams', '$rootScope', 'ProjectService', function ($scope, $http, $stateParams, $rootScope, projectService) {

	$scope.init = function(){
        $scope.projectId = $stateParams.id;
	}

	$scope.newIssue = function () {
	    $rootScope.$broadcast('popup:newissue:open');
	}
}]);

