(function () {
	var codemash2014 = angular.module('codemash2014', []);

	codemash2014.controller('bindingDemoCtrl', ['$scope', function ($scope) {
		$scope.textStuff = 'World';
	}]);

	codemash2014.controller('collectionBindingCtrl', ['$scope', function ($scope) {
		$scope.names = ['Leprechaun', 'Unicorn', 'Bacon'];
	}]);
})();