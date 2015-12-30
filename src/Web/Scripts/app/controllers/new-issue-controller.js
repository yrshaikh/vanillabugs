angular.module('project-management').controller('NewIssueController',
 ['$scope', '$rootScope', '$timeout', '$window', '$stateParams', 'ProjectService', 'IssueService', function ($scope, $rootScope, $timeout, $window, $stateParams, projectService, issueService) {

     $rootScope.$on('popup:newissue:open', function () {
         $scope.newIssuePopupOpen = true;
         focusElement();
         resetForm();
     });

     $scope.closeNewIssuePopup = function () {
         $scope.newIssuePopupOpen = false;
     }
     
     $scope.init = function () {
         $scope.popupNewIssueOpen = false;
         resetForm();
         $scope.projectList = {
             loading: true,
             data: false
         }
         $scope.issueStatuses = {
             loading: true,
             data: false
         };
         $scope.issuePriorities = {
             loading: true,
             data: false
         };
         $scope.issueTypes = {
             loading: true,
             data: false
         };
         fillDropdowns();
     };

     resetForm = function () {
         var projectId = $stateParams.id;
         console.log(projectId);
         $scope.issue = {
             projectId: parseInt(projectId),
             name: '',
             type: 1,
             priority: 2,
             saving: false,
             saveSuccess: false,
             saveFailure: false,
             saveFailureDuplicate: false
         };
     }

     var focusElement = function () {
         var id = "issuetitle";
         $timeout(function() {
             var element = $window.document.getElementById(id);
             if (element)
                 element.focus();
         });
     }

     var fillDropdowns = function() {
         initializeProjectList();
         initializeIssueStatusList();
         initializeIssuePriorityList();
         initializeIssueTypeList();
     }

     var initializeProjectList = function () {
         projectService.getAllProjects()
             .success(function(response) {
                 $scope.projectList.loading = false;
                 $scope.projectList.data = response.data;
             });
     }

     var initializeIssueStatusList = function () {
         issueService.getIssueStatusList()
             .success(function (response) {
                 $scope.issueStatuses.loading = false;
                 $scope.issueStatuses.data = response;
             });
     }
     var initializeIssuePriorityList = function () {
         issueService.getIssuePriorityList()
             .success(function (response) {
                 $scope.issuePriorities.loading = false;
                 $scope.issuePriorities.data = response;
             });
     }
     var initializeIssueTypeList = function () {
         issueService.getIssueTypeList()
             .success(function (response) {
                 $scope.issueTypes.loading = false;
                 $scope.issueTypes.data = response;
             });
     }

     $scope.saveProject = function () {
         $scope.project.saving = true;
         $scope.project.saveFailure = false;
         $scope.project.saveFailureDuplicate = false;
         projectService.createNewProject($scope.project.name)
             .success(function (response) {
                 $scope.project.saving = false;
                 if (response.errmsg && response.errmsg.indexOf('duplicate') != -1)
                     $scope.project.saveFailureDuplicate = true;
             })
             .error(function () {
                 $scope.project.saving = false;
                 $scope.project.saveFailure = true;
             });
     }
 }]);