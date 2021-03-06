angular.module("project-management").factory('IssueService', ['$http', function ($http) {
    return {
        createNewIssue: function(data) {
            return $http({
                url: '/issue/create',
                method: 'POST',
                data: data
            });
        },
        getAllIssues: function() {
            return $http({
                url: '/project/get',
                method: 'GET'
            });
        },
        getIssueStatusList: function () {
            return $http({
                url: '/master/issuestatuses',
                method: 'GET'
            });
        },
        getIssuePriorityList: function () {
            return $http({
                url: '/master/issuepriorities',
                method: 'GET'
            });
        },
        getIssueTypeList: function () {
            return $http({
                url: '/master/issuetypes',
                method: 'GET'
            });
        }
    };
}]);