// I wasn't sure is this correct so i made
//another function comented at the bottom.

(function () {
	'use strict';

	var canvas = document.getElementById('canvas');
	var canvasCtx = canvas.getContext('2d');

	var Shapes = (function () {

		function Rect(x, y, width, height) {
			this._x = x;
			this._y = y;
			this._width = width;
			this._height = height;

			Rect.prototype.CanvasDraw = function () {
				canvasCtx.beginPath();
				canvasCtx.rect(this._x, this._y, this._width, this._height);
				canvasCtx.fill();
				canvasCtx.stroke();
			};
		}

		function Circle(x, y, radius) {
			this._x = x;
			this._y = y;
			this._radius = radius;

			Circle.prototype.CanvasDraw = function () {
				canvasCtx.beginPath();
				canvasCtx.arc(this._x, this._y, this._radius, 0, 2 * Math.PI);
				canvasCtx.fill();
				canvasCtx.stroke();
			};
		}

		function Line(x1, y1, x2, y2) {
			this._x1 = x1;
			this._y1 = y1;
			this._x2 = x2;
			this._y2 = y2;

			Line.prototype.CanvasDraw = function () {
				canvasCtx.beginPath();
				canvasCtx.moveTo(this._x1, this._y1);
				canvasCtx.lineTo(this._x2, this._y2);
				canvasCtx.stroke();
			}
		}

		return {
			Rect: Rect,
			Circle: Circle,
			Line: Line
		}
	}());

	canvasCtx.fillStyle = 'lightblue';
	canvasCtx.strokeStyle = 'darkcyan';

	var rect = new Shapes.Rect(50, 50, 200, 300);
	var circle = new Shapes.Circle(800, 300, 150);
	var line = new Shapes.Line(50, 450, 950, 50);

	rect.CanvasDraw();
	circle.CanvasDraw();
	line.CanvasDraw();
})();

//(function () {
//	'use strict';

//	var canvas = document.getElementById('canvas');
//	var canvasCtx = canvas.getContext('2d');

//	var canvasDraw = (function() {

//		function rect(x, y, width, height) {
//			canvasCtx.beginPath();
//			canvasCtx.rect(x, y, width, height);
//			canvasCtx.stroke();
//			canvasCtx.fill();
//		}

//		function circle(x, y, radius) {
//			canvasCtx.beginPath();
//			canvasCtx.arc(x, y, radius, 0, 2 * Math.PI);
//			canvasCtx.stroke();
//			canvasCtx.fill();
//		}

//		function line(x1, y1, x2, y2) {
//			canvasCtx.beginPath();
//			canvasCtx.moveTo(x1, y1);
//			canvasCtx.lineTo(x2, y2);
//			canvasCtx.stroke();
//		}

//		return {
//			rect:  rect,
//			circle:  circle,
//			line: line 
//		}
//	}());

//	canvasCtx.fillStyle = 'lightblue';
//	canvasCtx.strokeStyle = 'darkcyan';

//	canvasDraw.rect(50, 50, 200, 300);
//	canvasDraw.circle(800, 300, 150);
//	canvasDraw.line(50, 450, 950, 50);
//})();