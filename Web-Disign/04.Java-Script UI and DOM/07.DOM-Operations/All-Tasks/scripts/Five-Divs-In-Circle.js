window.onload = function () {
	"use strict"

	var divCount = 5,
		centerX = 200,
		centerY = 200,
		radius = 150,
		angle = 0;

	function createDivs() {

		var root = document.getElementById('root'),
			rootFragment = document.createDocumentFragment();

		for (var i = 0; i < divCount; i += 1) {
			var currentDiv = document.createElement('div');
			var text = document.createElement('strong');

			currentDiv.id = 'div' + i;
			text.innerHTML = 'div' + (i + 1);
			currentDiv.appendChild(text);
			currentDiv.style.border = '1px solid black';

			rootFragment.appendChild(currentDiv);
		}
		root.appendChild(rootFragment);
	}

	function frame() {
		angle += 0.05;

		if (angle == 360) {
			angle = 0;
		}

		for (var i = 0; i < divCount; i += 1) {

			var divID = 'div' + i,
				spaceBetweenDivs = (360 / divCount) * i,
				radians = 2 * Math.PI / 180;

			var left = centerX + Math.cos((radians) * (angle + spaceBetweenDivs)) * radius;
			var top = centerY + Math.sin((radians) * (angle + spaceBetweenDivs)) * radius;

			var currDiv = document.getElementById(divID);
			currDiv.style.position = 'absolute';	
			currDiv.style.left = left + 'px';
			currDiv.style.top = top + 'px';
		}

		window.requestAnimationFrame(frame);
	}

	createDivs();
	frame();
}