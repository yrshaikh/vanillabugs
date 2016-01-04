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
         $scope.projectUsers = {
             loading: true,
             data: false
         };
         fillDropdowns();
         $scope.pageConstants = {
             unassigned: 'unassigned'
         }
     };

     resetForm = function () {
         var projectId = $stateParams.id;
         $scope.issue = {
             projectId: parseInt(projectId),
             title: '',
             description: null,
             type: 1,
             priority: 2,
             saving: false,
             saveSuccess: false,
             saveFailure: false,
             assignee: $scope.issue ? ($scope.issue.assignee) : null
         };
     }

     var focusElement = function () {
         var id = "issuetitle";
         UiHelpers.dom.focusElement(id);
     }

     var fillDropdowns = function () {
         initializeProjectList();
         initializeIssueStatusList();
         initializeIssuePriorityList();
         initializeIssueTypeList();
         initializeProjectUserList();
     }

     var initializeProjectList = function () {
         projectService.getAllProjects()
             .then(function (response) {
                 console.log(response);
                 $scope.projectList.loading = false;
                 $scope.projectList.data = response.data.data;
             })
            .then(function () {
                var defaultSelection = _.find($scope.projectList.data, { Id: $scope.issue.projectId });
                genericSelect2Wrapper("#projects", { id: defaultSelection.Id, text: defaultSelection.Name });
            });
     }

     var initializeIssueStatusList = function () {
         issueService.getIssueStatusList()
             .then(function (response) {
                 $scope.issueStatuses.loading = false;
                 $scope.issueStatuses.data = response.data;
             });
     }
     var initializeIssuePriorityList = function () {
         issueService.getIssuePriorityList()
             .then(function (response) {
                 $scope.issuePriorities.loading = false;
                 $scope.issuePriorities.data = response.data;
             })
             .then(function () {
                 var defaultSelection = _.find($scope.issuePriorities.data, { Id: $scope.issue.priority });
                 genericSelect2Wrapper("#priorities", { id: defaultSelection.Id, text: defaultSelection.Name });
             });
     }
     var initializeIssueTypeList = function () {
         issueService.getIssueTypeList()
             .then(function (response) {
                 $scope.issueTypes.loading = false;
                 $scope.issueTypes.data = response.data;
             })
             .then(function () {
                 var defaultSelection = _.find($scope.issueTypes.data, { Id: $scope.issue.type });
                 genericSelect2Wrapper("#types", { id: defaultSelection.Id, text: defaultSelection.Name });
             });
     }
     var initializeProjectUserList = function () {
         var projectId = $scope.issue.projectId;
         projectService.getProjectUsers(projectId)
             .then(function (response) {
                 $scope.projectUsers.loading = false;
                 $scope.projectUsers.data = response.data;
                 $scope.projectUsers.data.push({ Id: $scope.pageConstants.unassigned, FirstName: 'Unassigned', LastName: '' });
                 $scope.issue.assignee = $scope.pageConstants.unassigned;
             })
             .then(function () {
                 var defaultSelection = _.find($scope.projectUsers.data, { Id: $scope.issue.assignee });
                 genericSelect2Wrapper("#assignees", { id: defaultSelection.Id, text: defaultSelection.FirstName });
             });
     }

     var genericSelect2Wrapper = function (identifier, defaults) {
         $(identifier).select2();

         if (defaults)
             $(identifier).select2("data", defaults);
     }

     $scope.saveIssue = function () {

         var issue = angular.copy($scope.issue);
         delete issue.saving;
         delete issue.saveFailure;
         delete issue.saveSuccess;

         if (issue.assignee === $scope.pageConstants.unassigned)
             issue.assignee = null;

         $scope.issue.saving = true;
         $scope.issue.saveFailure = false;

         console.log(issue);
         issueService.createNewIssue(issue)
             .success(function (response) {
                 $scope.issue.saving = false;
                 if (response.errmsg)
                     $scope.issue.saveFailure = true;
                 else {
                     alert("issue created, you should be redirected.");
                 }
             })
             .error(function () {
                 $scope.issue.saving = false;
                 $scope.issue.saveFailure = true;
             });
     }
 }]);