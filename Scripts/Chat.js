
/// <reference path="angular.min.js" />
/// <reference path="jquery.signalr-2.4.2.min.js" />



(function () {
    var app = angular.module("chat-app", []);

    app.controller("ChatController", function ($scope) {
        $scope.name = "StartChating";
        $scope.message = "";
        $scope.messages = [];
        $scope.chatHub = null;

        $scope.chatHub = $.connection.chatHub;
        $.connection.hub.start().done(function () {
            console.log("connected");
        });

        $scope.chatHub.client.broadcastMessage = function (name, message) {
            //var dt = "";
            //dt = "(" + $filter('date')(datetime, "yyyy-MM-dd hh:mm:ss") + ")";

            var newMessage = name + " : " + message;
            $scope.messages.push(newMessage);
            $scope.$apply();
            console.log("Show");
        }
        $scope.newMessage = function () {
            $scope.chatHub.server.sendMessage($scope.name, $scope.message);
            $scope.message = "";
            console.log("sent");

        }
    });
}());

