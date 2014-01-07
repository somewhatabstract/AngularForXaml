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

	codemash2014.value('errorColor', 'red');
	codemash2014.value('okColor', 'green');

	codemash2014.service('statusColorService', ['errorColor', 'okColor', function(errorColor, okColor) {
		this.getTextColor = function(hasError) {
			return hasError ? errorColor : okColor;
		};
	}]);

	codemash2014.controller('colorBindingCtrl', ['$scope', 'statusColorService', function($scope, statusColorService) {
		$scope.hasError = false;
		$scope.getTextColor = function(hasError) {
			return statusColorService.getTextColor(hasError);
		};
	}]);

	codemash2014.value('insultWords', {
		firstAdjectives: [
			"artless",
			"bawdy",
			"beslubbering",
			"bootless",
			"churlish",
			"cockered",
			"clouted",
			"craven",
			"currish",
			"dankish",
			"dissembling",
			"droning",
			"errant",
			"fawning",
			"fobbing",
			"froward",
			"frothy",
			"gleeking",
			"goatish",
			"gorbellied",
			"impertinent",
			"infectious",
			"jarring",
			"loggerheaded",
			"lumpish",
			"mammering",
			"mangled",
			"mewling",
			"paunchy",
			"pribbling",
			"puking",
			"puny",
			"qualling",
			"rank",
			"reeky",
			"roguish",
			"ruttish",
			"saucy",
			"spleeny",
			"spongy",
			"surly",
			"tottering",
			"unmuzzled",
			"vain",
			"venomed",
			"villainous",
			"warped",
			"wayward",
			"weedy",
			"yeasty"],
		secondAdjectives: [
			"base-court",
			"bat-fowling",
			"beef-witted",
			"beetle-headed",
			"boil-brained",
			"clapper-clawed",
			"clay-brained",
			"common-kissing",
			"crook-pated",
			"dismal-dreaming",
			"dizzy-eyed",
			"dog-hearted",
			"dread-bolted",
			"earth-vexing",
			"elf-skinned",
			"fat-kidneyed",
			"fen-sucked",
			"flap-mouthed",
			"fly-bitten",
			"folly-fallen",
			"fool-born",
			"full-gorged",
			"guts-griping",
			"half-faced",
			"hasty-witted",
			"hedge-born",
			"hell-hated",
			"idle-headed",
			"ill-breeding",
			"ill-nurtured",
			"knotty-pated",
			"milk-livered",
			"motley-minded",
			"onion-eyed",
			"plume-plucked",
			"pottle-deep",
			"pox-marked",
			"reeling-ripe",
			"rough-hewn",
			"rude-growing",
			"rump-fed",
			"shard-borne",
			"sheep-biting",
			"spur-galled",
			"swag-bellied",
			"tardy-gaited",
			"tickle-brained",
			"toad-spotted",
			"unchin-snouted",
			"weather-bitten"],
		nouns: [
			"apple-john",
			"baggage",
			"barnacle",
			"bladder",
			"boar-pig",
			"bugbear",
			"bum-bailey",
			"canker-blossom",
			"clack-dish",
			"clotpole",
			"coxcomb",
			"codpiece",
			"death-token",
			"dewberry",
			"flap-dragon",
			"flax-wench",
			"flirt-gill",
			"foot-licker",
			"fustilarian",
			"giglet",
			"gudgeon",
			"haggard",
			"harpy",
			"hedge-pig",
			"horn-beast",
			"hugger-mugger",
			"joithead",
			"lewdster",
			"lout",
			"maggot-pie",
			"malt-worm",
			"mammet",
			"measle",
			"minnow",
			"miscreant",
			"moldwarp",
			"mumble-news",
			"nut-hook",
			"pigeon-egg",
			"pignut",
			"puttock",
			"pumpion",
			"ratsbane",
			"scut",
			"skainsmate",
			"strumpet",
			"varlot",
			"vassal",
			"whey-face",
			"wagtail"]
	});

	codemash2014.controller('insultGeneratorCtrl', function($scope, insultWords) {
		$scope.firstAdjectives = insultWords.firstAdjectives;
		$scope.secondAdjectives = insultWords.secondAdjectives;
		$scope.nouns = insultWords.nouns;

		$scope.randomize = function() {
			$scope.firstAdjective = getRandomElement($scope.firstAdjectives);
			$scope.secondAdjective = getRandomElement($scope.secondAdjectives);
			$scope.noun = getRandomElement($scope.nouns);
		};

		function getRandomIndex(limit) {
			return Math.round(limit * Math.random() + 0.5);
		}

		function getRandomElement(array) {
			var index = getRandomIndex(array.length - 1);
			return array[index];
		}

		$scope.randomize();
	});

	codemash2014.directive('labelledCombo', function() {
		return {
			template: '<div><div class="label">{{title}}</div><select ng-model="selectedItem" ng-options="item for item in items"></select></div>',
			restrict: 'E',
			replace: true,
			scope: {
				selectedItem: '=',
				items: '=',
				title: '@'
			}
		};
	});

	codemash2014.directive('insultGenerator', function() {
		return {
			controller: 'insultGeneratorCtrl',
			replace:true,
			template:
				'<div class="insult-generator">'
				+ '<labelled-combo title="Adjective 1:" items="firstAdjectives" selected-item="firstAdjective"></labelled-combo>'
				+ '<labelled-combo title="Adjective 2:" items="secondAdjectives" selected-item="secondAdjective"></labelled-combo>'
				+ '<labelled-combo title="Noun:" items="nouns" selected-item="noun"></labelled-combo>'
				+ '<div>'
					+ '<button ng-click="randomize()">Randomize</button>'
					+ '<div class="insult-container"><textarea class="insult" readonly rows="2">Thou {{firstAdjective}} {{secondAdjective}} {{noun}}!</textarea></div>'
				+ '</div>'
			  + '</div>',
			restrict: 'E',
			scope: {}
		};
	});
})();