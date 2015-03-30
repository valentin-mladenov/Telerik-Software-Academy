window.onload = function () {
	"use strict"

	function randomFromMinToMax(min, max) {
		return Math.floor((Math.random() * (max - min)) + min);
	}

	function randomColor() {
		return 'rgb(' + randomFromMinToMax(0, 255) + ', ' + randomFromMinToMax(0, 255) +
				', ' + randomFromMinToMax(0, 255) + ')';
	}

	function randomLengthInPixels(min, max) {
		return (randomFromMinToMax(min, max) + 'px').toString();
	}

	function createRandomDivs() {
		var root = document.getElementById('root'),
			count = 20,
			rootFragment = document.createDocumentFragment();

		for (var i = 0; i < count; i += 1) {
			var currentDiv = document.createElement('div');

			// Random width and height between 20px and 100px
			currentDiv.style.height = randomLengthInPixels(20,100);
			currentDiv.style.width = randomLengthInPixels(20,100);

			// Random background color
			currentDiv.style.backgroundColor = randomColor();

			// Random font color
			currentDiv.style.color = randomColor();

			// Random position on the screen (position:absolute)
			currentDiv.style.position = 'absolute';
			currentDiv.style.left = randomLengthInPixels(1,500);
			currentDiv.style.top = randomLengthInPixels(1,500);

			// A strong element with text "div" inside the div
			var title = document.createElement('strong');
			title.innerHTML = 'div' + (i + 1);
			currentDiv.appendChild(title);

			// Random border radius	
			currentDiv.style.borderRadius = randomLengthInPixels(1,15);

			// Random border color
			var borderColor = randomColor();

			// Random border width between 1px and 20px
			currentDiv.style.border = (randomFromMinToMax(1, 20) + 'px solid ' + borderColor).toString();

			rootFragment.appendChild(currentDiv);
		}

		root.appendChild(rootFragment);
	}

	createRandomDivs();
};