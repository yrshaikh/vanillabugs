angular.module('project-management').controller('NewProjectController',
    ['$scope', '$location', '$rootScope', '$timeout', 'ProjectService', function ($scope, $location, $rootScope, $timeout, projectService) {

        $rootScope.$on('popup:newproject:open', function() {
            $scope.newProjectPopupOpen = true;
        });

        $scope.closeNewProjectPopup = function () {
            $scope.newProjectPopupOpen = false;
        }

        $scope.init = function () {
            $scope.newProjectPopupOpen = false;
            $scope.project = {
                name: '',
                saving: false,
                saveSuccess: false,
                saveFailure: false,
                saveFailureDuplicate: false
            };
        }
        $scope.saveProject = function () {
            $scope.project.saving = true;
            $scope.project.saveFailure = false;
            $scope.project.saveFailureDuplicate = false;
            projectService.createNewProject($scope.project.name)
                .success(function (response) {
                    $scope.project.saving = false;
                    if (response.createdSuccessfully) {
                        $scope.project.saveSuccess = true;
                        $timeout(function() {
                            $location.path('/project/' + response.projectId + '/issues');
                        }, 1000);
                    } else {
                        //$scope.project.saveFailureDuplicate = true;
                        $scope.project.saveFailure = true;
                    };

                })
                .error(function () {
                    $scope.project.saving = false;
                    $scope.project.saveFailure = true;
                });
        }
    }]);