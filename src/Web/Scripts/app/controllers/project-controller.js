angular.module('project-management').controller('ProjectController',
	['$scope', '$http', '$modal', 'ProjectService', '$rootScope', '$stateParams', function ($scope, $http, $modal, projectService, $rootScope, $stateParams) {

	$scope.init = function() {
	    $scope.project = {
			loading: false,
			data: []
	    };
	    var projectId = $stateParams.id;
	    getProjectDetails(projectId);
	}

	var getProjectDetails = function(projectId){
		projectService.getProjectDetails(projectId)
			.then(function(response){
				$scope.project.loading = false;
				$scope.project.data = response.data.project;
		    });
	};
}]);

