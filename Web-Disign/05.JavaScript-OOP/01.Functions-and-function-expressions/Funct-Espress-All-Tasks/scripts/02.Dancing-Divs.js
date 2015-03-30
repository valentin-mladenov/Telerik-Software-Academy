(function () {
	'use strict';

	var movingShapes = (function () {
		var centerX = 200,
			divEclipseCount = 0,
			centerY = 200,
			radius = 150,
			angle = 0;

		var rectHeightWidth = 150,
			divRectCount = 0,
			rectTop = 100,
			rectLeft = 100,
			moveCount = 1,
			moveLeft,
			spaceBetweenRectDivs = 50,
			moveTop = 150;

		function randomFromMinToMax(min, max) {
			return Math.floor((Math.random() * (max - min)) + min);
		}

		function randomColor() {
			return 'rgb(' + randomFromMinToMax(0, 255) + ', ' + randomFromMinToMax(0, 255) +
				', ' + randomFromMinToMax(0, 255) + ')';
		}

		function createRandomDiv(movementFigure) {
			var wrapper = document.getElementById('wrapper'),
				currentDiv = document.createElement('div');

			currentDiv.style.height = '30px';
			currentDiv.style.width = '30px';
			currentDiv.style.backgroundColor = randomColor();
			currentDiv.style.color = randomColor();
			currentDiv.style.borderRadius = '20px';

			if (movementFigure === 'eclipse') {
				divEclipseCount += 1;
				currentDiv.id = 'eclipse' + divEclipseCount;
				currentDiv.style.borderRadius = '20px';
			} else {
				divRectCount += 1;
				currentDiv.id = 'rect' + divRectCount;
				currentDiv.className = "right";
				currentDiv.style.left = (spaceBetweenRectDivs * (divRectCount - 1) + rectLeft) + 'px';
				currentDiv.style.top = rectTop + 'px';
				currentDiv.style.borderRadius = '5px';
			}

			var title = document.createElement('strong');
			title.innerHTML = 'div';
			currentDiv.appendChild(title);

			var borderColor = randomColor();
			currentDiv.style.border = '3px solid ' + borderColor.toString();

			wrapper.appendChild(currentDiv);
		}

		function move() {

			function eclipseMovement() {
				angle += 0.1;

				if (angle == 360) {
					angle = 0;
				}

				for (var i = 1; i <= divEclipseCount; i += 1) {

					var divID = 'eclipse' + i,
						spaceBetweenDivs = (360 / divEclipseCount) * (i - 1),
						radians = 2 * Math.PI / 180;

					if (divEclipseCount == 2) {
						spaceBetweenDivs = 180 / i;
					}

					var left = centerX + Math.cos((radians) * (angle + spaceBetweenDivs)) * radius;
					var top = centerY + Math.sin((radians) * (angle + spaceBetweenDivs)) * radius;

					var currDiv = document.getElementById(divID);
					currDiv.style.position = 'absolute';
					currDiv.style.left = left + 'px';
					currDiv.style.top = top + 'px';
				}

			}

			function rectMovement() {
				for (var i = 1; i <= divRectCount; i += 1) {
					var divId = 'rect' + i;
					var currDiv = document.getElementById(divId);
					var divClassName = currDiv.className;
					moveLeft = parseInt(currDiv.style.left);
					moveTop = parseInt(currDiv.style.top);

					if (divClassName=="up") {
						if (moveTop + rectTop >= rectHeightWidth) {
							moveTop -= moveCount ;
						} else {
							currDiv.className = 'right';
						}
					}

					if (divClassName=="down") {
						if (moveTop <= rectHeightWidth + rectTop) {
							moveTop += moveCount;
						} else {
							currDiv.className = 'left';
						}
					}

					if (divClassName == "right") {
						if (moveLeft <= rectHeightWidth + rectLeft) {
							moveLeft += moveCount;
						} else {
							currDiv.className = 'down';
						}
					}

					if (divClassName == "left") {
						if (moveLeft + rectLeft >= rectHeightWidth) {
							moveLeft -= moveCount;
						} else {
							currDiv.className = 'up';
						}
					}
					
					currDiv.style.position = 'absolute';
					currDiv.style.left = moveLeft + 'px';
					currDiv.style.top = moveTop + 'px';
				}
			}

			eclipseMovement();
			rectMovement();

			window.requestAnimationFrame(move);
		}

		function add(movementFigure) {
			createRandomDiv(movementFigure);
		}

		return {
			add: add,
			move: move
		}
	}());

	movingShapes.add("eclipse");
	movingShapes.add("eclipse");
	movingShapes.add("eclipse");

	movingShapes.add("rect");
	movingShapes.add("rect");
	movingShapes.add("rect");

	movingShapes.move();
}());