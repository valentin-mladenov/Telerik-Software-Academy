window.onload = function () {
	"use strict"

	function createTextAreaAndColors() {
		var root = document.getElementById('root'),
			textArea = document.createElement('textarea'),
			fontColor = document.createElement('input'),
			backColor = document.createElement('input'),
			rootFragment = document.createDocumentFragment();

		textArea.id = 'textArea';
			
		fontColor.type = 'color';
		fontColor.id = 'fontColor';

		backColor.type = 'color';
		backColor.id = 'backColor';

		rootFragment.appendChild(textArea);
		rootFragment.appendChild(fontColor);
		rootFragment.appendChild(backColor);

		root.appendChild(rootFragment);
	}
	createTextAreaAndColors();

	var textArea = document.getElementById('textArea'),
		font = document.getElementById('fontColor'),
		back = document.getElementById('backColor');

	// i have to use functions this way, when i try to call
	// a function outside nothing happens. I supose i can write them in varibles?!
	font.addEventListener('change', function () {
		textArea.style.color = font.value;
	});

	back.addEventListener('change', function () {
		textArea.style.backgroundColor = back.value;
	});
};