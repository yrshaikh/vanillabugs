angular.module('project-management').controller('DashboardController', 
	['$scope', '$http', 'ProjectService', '$rootScope', function ($scope, $http, projectService, $rootScope) {
	
	$scope.init = function(){
        $scope.subNavEnabled = false;
		$scope.projects = {
			data: [],
			loading: false
		};
	    loadProjects();
	}

	var loadProjects = function(){
	    $scope.projects.loading = true;
	    projectService.getAllProjects()
			.then(function(response){
                $scope.projects.loading = false;
				$scope.projects.data = response.data.data;
			});
	};

	$scope.newProject = function () {
	    $rootScope.$broadcast('popup:newproject:open');
	}
}]);

