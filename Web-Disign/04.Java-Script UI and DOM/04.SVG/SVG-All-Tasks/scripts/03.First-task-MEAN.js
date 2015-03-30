var svgNS = 'http://www.w3.org/2000/svg';
var svg = document.createElementNS(svgNS, 'svg');
svg.setAttribute('width', '500');
svg.setAttribute('height', '500');
document.body.appendChild(svg);

var repetitionsCount = 4;
var circleStartX = 150;
var textStartX = 30;
var startY = 50;
var radius = 60;
var fontSize = '40px';
var colors = ['grey', 'black', 'red', 'yellowgreen', 'green'];
var word = ['MEAN', 'express'];
var OrderedFunctions = [
	function drawLeaf() {
		drawPath('yellowgreen', 'yellowgreen', 'M 150 30 C120 50 150 70 150 70', 1);
		drawPath('green', 'green', 'M  150 30 C180 50 150 70 150 70', 1);
	},
	function drawExpress() {
		writeTextOnThePage(105, 125, 24, 'white', word[1], 'Consolas');
	},
	function drawAngularJs() {
		drawPath('darkred', 'lightgrey', 'M150 170 L170 180 L150 230', 2);
		drawPath('red', 'lightgrey', 'M150 170 L130 180 L150 230', 2);
		drawPath('red', 'white', 'M150 180 L130 230', 3);
		drawPath('red', 'lightgrey', 'M150 180 L170 230', 3);
	}
];

function createCircle(x, y, r, fill) {
	var circle = document.createElementNS(svgNS, 'circle');
	circle.setAttribute('cx', x);
	circle.setAttribute('cy', y);
	circle.setAttribute('r', r);
	circle.setAttribute('stroke', 'none');
	circle.setAttribute('fill', fill);

	svg.appendChild(circle);
}

function writeTextOnThePage(x, y, fontSize, color, innerText, fontFamily) {
	var text = document.createElementNS(svgNS, 'text');
	text.setAttribute('x', x);
	text.setAttribute('y', y);
	text.setAttribute('font-size', fontSize);
	text.setAttribute('fill', color);
	text.setAttribute('font-family', fontFamily),
	text.innerHTML = innerText;
	svg.appendChild(text);

}

function drawPath(fillColor, strokeColor, d, strokeWidth) {
	var leftCurve = document.createElementNS(svgNS, 'path');
	leftCurve.setAttribute('d', d);
	leftCurve.setAttribute('fill', fillColor);
	leftCurve.setAttribute('stroke', strokeColor);
	leftCurve.setAttribute('stroke-width', strokeWidth);
	svg.appendChild(leftCurve);
}

function drawPoligon(fillcolor, strokeColor, points){
	var polygon = document.createElementNS(svgNS,'polygon');
	polygon.setAttribute('fill', fillcolor);
	polygon.setAttribute('stroke', strokeColor);
	polygon.setAttribute('points', points);
	svg.appendChild(polygon);
}

//draw everything with a loop
for (var i = 0; i < repetitionsCount; i++) {
	createCircle(circleStartX, startY, radius, colors[i]);
	writeTextOnThePage(textStartX, startY, fontSize, colors[i], word[0][i], 'Consolas');
	if (OrderedFunctions[i]) {
		OrderedFunctions[i]();
	}
	startY += 70;
}

drawPath('#42413D', 'none', 'M110 270 L110 250 L118 245 L126 250 L126 270 L120 265 L120 255 L118 253 L115 255 L115 265 Z', '0')
drawPoligon('white', 'none', "130,250 138,245 146,250 146,270 138,275 130,270");
drawPoligon('#42413D', 'none', "150,250 158,245 166,250 166,270 158,275 150,270");
drawPoligon('#8EC74E', 'none', "154,255 158,252 162,255 162,265 158,268 154,265");
drawPath('#42413D', 'none', 'M166 250 L166 235 L162 230 L162 250');
drawPoligon('#42413D', '#8EC74E', '170,250 178,245 186,250 186,270 178,275 170,270');
drawPoligon('white', 'none', '174,255 178,252 182,255 182,265 178,268 174,265');
drawPath('#8EC74E', 'none', 'M186 270 L182 265 L182 260 L186 255', '0')