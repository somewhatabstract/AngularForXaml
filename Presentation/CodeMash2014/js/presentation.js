(function () {
	var codemash2014 = angular.module('codemash2014', []);

	codemash2014.controller('bindingDemoCtrl', ['$scope', function ($scope) {
		$scope.textStuff = 'World';
	}]);

	codemash2014.controller('collectionBindingCtrl', ['$scope', function ($scope) {
		$scope.names = ['Leprechaun', 'Unicorn', 'Bacon'];
	}]);

	codemash2014.controller('reverseCtrl', ['$scope', function($scope) {
		$scope.stringToReverse = 'Hello World';
	}]);

	codemash2014.controller('presentationBindingCtrl', ['$scope', function($scope) {
		$scope.isShowingSurprise = false;
		$scope.hasError = false;

		$scope.errorColor = $scope.hasError ? 'red' : 'green';
	}]);

	codemash2014.filter('reverse', function() {
		return function(value) {
			return value.split("").reverse().join("");;
		};
	});

	codemash2014.directive('statusMessageSimple', function() {
		return {
			template: '<div>Our status message</div>',
			restrict: 'E'
		};
	});

	codemash2014.directive('statusMessage', function() {
		return {
			template: '<div>{{message}}</div>',
			restrict: 'E',
			scope: { message: '@' }
		};
	});
})();