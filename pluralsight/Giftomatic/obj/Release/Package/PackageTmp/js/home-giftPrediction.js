// home-giftPrediction.js
var giftPredictionModule = angular.module("giftPrediction", []);

homeIndexModule.config(["$routeProvider", function ($routeProvider) {
  $routeProvider.when("/:senderId", {
    controller: "userFormController",
    templateUrl: "/templates/userFormView.html"
  });

  $routeProvider.when("/predictionResult/:id/:senderId", {
    controller: "predictionResultController",
    templateUrl: "/templates/predictionResultView.html"
  });

  $routeProvider.otherwise({ redirectTo: "/" });
}]);

homeIndexModule.factory("predictionService", ["$http", "$q", function ($http, $q) {

  var _items = [];              // To house all items. Might be superfluous.
  var _predictedItems = [];     // To house the predicted items. Preferrably with the features to be presented as well.
  var _userId;                  // This variable is to be kept throughout the visit in /GiftPrediction/
  var _senderId;                // -||-, in case it is used from a sender that wishes to get the results via mail.

  var _isInit = false;          // Don't know if this will be necessary.

  var _isReady = function () {
    return _isInit;
  }

  // This would be the equivalent to _getPrediction.
  // Question is whether or not to perform all posts
  //  and gets in here.
  var _getTopics = function () {

    var deferred = $q.defer();

    $http.get("/api/v1/topics?includeReplies=true")
      .then(function (result) {
        // Successful
        angular.copy(result.data, _topics);
        _isInit = true;
        
        deferred.resolve();
      },
      function () {
        // Error
        deferred.reject();
      });

    return deferred.promise;
  };
  
  var _

  var _getPrediction = function (newSetOfUserFeatures) {
    var deferred = $q.defer();
    var newUser;
    var externalFeatures;
    var itemFeatures;

    $http.post("/api/v1/userFeatures/", newSetOfUserFeatures)
      .then(function (result) {
        newUser = result.data;
      },
      function () {
        // error
        deferred.reject();
      });
    
    var zip = newSetOfUserFeatures.zip;
    var age = newSetOfUserFeatures.age;
    var gender = newSetOfUserFeatures.gender;
    var getParamString = "zip=" + zip + "&age=" + age + "&gender=" + gender;
    $http.get("/api/v1/externalFeatures?" + getParamString)
      .then(function (result) {
        externalFeatures = result.data;
        
        // How to make multiple defers and resolves?
        //deferred.resolve();
      },
      function () {
          // error
          deferred.reject();
      });

    $http.get("/api/v1/itemFeatures")
      .then(function (result) {
          itemFeatures = result.data;
      },
      function () {
          // error
          deferred.reject();
      });

    http.post("/api/v1//", newSetOfUserFeatures)
      .then(function (result) {
          newUser = result.data;
      },
      function () {
          // error
          deferred.reject();
      });

    return deferred.promise;
  }

  var _addTopic = function (newTopic) {
    var deferred = $q.defer();

    $http.post("/api/v1/topics", newTopic)
     .then(function (result) {
       // success
       var newlyCreatedTopic = result.data;
       _topics.splice(0, 0, newlyCreatedTopic);
       deferred.resolve(newlyCreatedTopic);
     },
     function () {
       // error
       deferred.reject();
     });

    return deferred.promise;
  };

  function _findTopic(id) {
    var found = null;

    $.each(_topics, function (i, item) {
      if (item.id == id) {
        found = item;
        return false;
      }
    });

    return found;
  }

  var _getTopicById = function (id) {
    var deferred = $q.defer();

    if (_isReady()) {
      var topic = _findTopic(id);
      if (topic) {
        deferred.resolve(topic);
      } else {
        deferred.reject();
      }
    } else {
      _getTopics()
        .then(function () {
          // success
          var topic = _findTopic(id);
          if (topic) {
            deferred.resolve(topic);
          } else {
            deferred.reject();
          }
        },
        function () {
          // error
          deferred.reject();
        });
    }

    return deferred.promise;
  };

  var _saveItemRatings = function (userFeatures, newSetOfItemRatings) {
      var deferred = $q.defer();

      $http.post("/api/v1/itemRatings/" + userFeatures.userId, )
  }

  var _saveReply = function (topic, newReply) {
    var deferred = $q.defer();

    $http.post("/api/v1/topics/" + topic.id + "/replies", newReply)
      .then(function (result) {
        // success
        if (topic.replies == null) topic.replies = [];
        topic.replies.push(result.data);
        deferred.resolve(result.data);
      },
      function () {
        // error
        deferred.reject();
      });

    return deferred.promise;
  };

  return {
    topics: _topics,
    getTopics: _getTopics,
    addTopic: _addTopic,
    getTopicById: _getTopicById,
    saveReply: _saveReply,
    predictedItems: _predictedItems,
    isReady: _isReady,
    getPrediction: _getPrediction,
    saveItemRatings: _saveItemRatings
  };
}]);

var userFormController = ["$scope", "$http", "$window", "$routeParams", "predictionService",
  function ($scope, $http, $window, $routeParams, predictionService) {
    $scope.getPrediction = function () {
      predictionService.getPrediction($scope.newSetOfUserFeatures, $routeParams.senderId)    
        .then(function () {
            // success
            $window.location = "/"
        });
    };
  }];

var predictionResultController = ["$scope", "$http", "$window", "$routeParams", "predictionService",
  function ($scope, $http, $window, $routeParams, predictionService) {
    $scope.data = dataService;
    $scope.isBusy = false;
        
    $scope.saveItemRatings = function () {
      dataService.saveItemRatings($scope.newSetOfItemRatings)
        .then(function () {
          // TODO:: Show some modal with ok information
          //  then redirect to about or something other
          $window.location = "/About/";
        },
        function () {
          // error
          alert("Warning :: \n Could not save your gift ratings. \n Please try again.");
        });
    };
  }];




