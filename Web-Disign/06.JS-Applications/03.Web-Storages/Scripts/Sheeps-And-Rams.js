$(document).ready(function () {
	$('#new-game-button').on('click', startGame);

	function startGame() {
		setStage();
	}

	function getRandomFourDigitNumber() {
		var min = 1000;
		var max = 9999;
		var num = Math.floor(Math.random() * (max - min)) + min;



		return num;
	}

	function setStage() {
		var generatedNumber,
            count = 0;

		function toGeneratedNumber() {
			var innerNum;
			while (true) {
				innerNum = getRandomFourDigitNumber().toString();
				var isAllDigitsDifferent = true,
					i,
					j;

				for (i = 0; i < 4; i+=1) {
					for (j = i; j < 3; j+=1) {
						if (innerNum[i] === innerNum[j+1]) {
							isAllDigitsDifferent = false;
							break;
						}
					}

					if (isAllDigitsDifferent===false) {
						break;
					}
				}

				if (isAllDigitsDifferent) {
					break;
				}
			}
			return innerNum;
		}

		generatedNumber = toGeneratedNumber();

		console.log(generatedNumber);

		$('#new-game-button').hide();

		$('#system-message').show();
		$('#player-input').show();
		$('#player-input').keypress(function (e) {
			var key_codes = [48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 0, 8];

			if (!($.inArray(e.which, key_codes) >= 0)) {
				e.preventDefault();
			}
		});
		$('#try-it-button').show();
		$('#player-input').val();
		$('#try-it-button').click(function () {
			count++;
			console.log('count: ' + count);
			checkSuggestion(generatedNumber, count);
		}
        );
	}

	function checkSuggestion(generatedNumber, count) {
		var value = parseInt($('#player-input').val()),
            sheep = 0,
            rams = 0;
		console.log(value);

		if (value < 1000) {
			$('#system-message').html('You must enter four digits!');
		}

		else {
			rams = checkForRams(generatedNumber, value);
			sheep = checkForSheep(generatedNumber, value);

			$('#sheep-rams-message').html('Rams: ' + rams + '<br>' + 'Sheep: ' + (sheep - rams));

			if (rams === 4) {
				$('#system-message').html('Congratulations! You did it with only ' + ((count == 1) ? count + ' shot' : count + ' shots') + '! <br> Please enter your nickname!');
				$('#try-it-button').hide();
				$('#player-input').hide();
				$('#sheep-rams-message').hide();
				$('#nickname-input').show();
				$('#enter-button').show().html('Enter').css('margin-top', '370px').click(function () {
					var nickName = $('#nickname-input').val();
					console.log(nickName);
					$('#enter-button').hide();
					localStorage.setItem(nickName, count);
					loadPairs();
				}
            )
			}
		}
	}

	function loadPairs() {
		var highScores = [],
            sortable = [],
            topFiveResults = '',
            playerResult = '',
            nickName,
            score;

		for (var i = 0; i < localStorage.length; i++) {
			nickName = localStorage.key(i);
			score = localStorage.getItem(nickName);
			highScores[nickName] = score;
		}

		for (var player in highScores)
			sortable.push([player, highScores[player]])
		sortable.sort(function (a, b) { return a[1] - b[1] })

		for (var i = 0; i < localStorage.length; i++) {
			playerResult = sortable[i][0] + ': ' + sortable[i][1] + ((sortable[i][1] == 1) ? ' shot' : ' shots');
			topFiveResults += playerResult + '<br>';
		}

		$('#sheep-rams-message').show().html(topFiveResults).css('margin-top', '20px');

	}

	function checkForRams(generatedNumber, value) {
		var firstValue = generatedNumber.toString(),
            secondValue = value.toString(),
            rams = 0,
            i;

		for (i = 0; i < 4; i++) {
			if (firstValue[i] === secondValue[i]) {
				rams++;
			}
		}

		return rams;
	}

	function checkForSheep(generatedNumber, value) {
		var firstValue = generatedNumber.toString(),
            secondValue = value.toString(),
            sheep = 0,
            i,
            j;

		for (i = 0; i < 4; i++) {
			for (j = 0; j < 4; j++) {
				if (firstValue[i] == secondValue[j]) {
					secondValue = secondValue.replaceAt(j, 'x');
					sheep++;
					break;
				}
			}
		}

		return sheep;
	};

	String.prototype.replaceAt = function (index, character) {
		return this.substr(0, index) + character + this.substr(index + character.length);
	}
});