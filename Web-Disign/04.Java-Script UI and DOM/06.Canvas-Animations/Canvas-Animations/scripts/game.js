/// <reference path="_references.js" />

window.onload = function () {
	mario();

	var paper = Raphael(0, 0, 1024, 653);

	var sky = paper.rect(paper.x, paper.y, paper.width, paper.height - 262);
	sky.attr({
		"fill": "90-#ADE5FF-#158EE7",
		"stroke": "none"
	});


	paper.image("images/ground.png", 0, paper.height - 264, paper.width, 264);

	clouds(paper);
}