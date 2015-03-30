
//Man module
function playGame() {
	var level = 160, // Game level, by decreasing will speed up
		pointWidth = 45, // Width of the size of one part from the snake or food
		pointHeight = 30, // Height of the size of one part from the snake or food
		incScore = 50, // Score
		snakeColor = "#4800ff",
		ctx, // Canvas attributes
		currentDirection = [], // current directions
		changeX = [-1, 0, 1, 0], // position adjusments
		changeY = [0, -1, 0, 1], // position adjusments
		queue = [],
		food = 1, // defalut food
		map = [],
		randomXY = Math.random,
		currentPositionX = 5 + (randomXY() * (pointWidth - 10)) | 0, // Calculate positions
		currentPositionY = 5 + (randomXY() * (pointHeight - 10)) | 0, // Calculate positions
		direction = randomXY() * 3 | 0,
		interval = 0,
		score = 0,
		sum = 0,
		easy = 0,
		i, dir;

	// getting play area
	var canvas = document.getElementById('playArea');
	ctx = canvas.getContext('2d');

	// Map positions
	for (i = 0; i < pointWidth; i++) {
		map[i] = [];
	}

	// Snake food Module
	function SnakeFood() {
		// random placement of snake food
		function randomFood() {
			var x, y;

			do {
				x = randomXY() * pointWidth | 0;
				y = randomXY() * pointHeight | 0;
			} while (map[x][y]);
			map[x][y] = 1;
			ctx.fillStyle = snakeColor;
			ctx.strokeRect(x * 10 + 1, y * 10 + 1, 8, 8);
		}

		return {
			createFood: randomFood
		}
	}
	// Default somewhere placement
	var snakeFood = new SnakeFood();
	snakeFood.createFood();

	// high Score Module
	function highScore(score) {
		var currScore = function() {
			var msgScore = document.getElementById("msg");
			msgScore.innerHTML = "Thank you for playing game.<br /> Your Score : <b>" + score + "</b><br /><br /><input type='button' value='Play Again' onclick='window.location.reload();' />";
			document.getElementById("playArea").style.display = 'none';
			window.clearInterval(interval);
		}

		return {
			points: currScore
		}
	}

	//Speed
	function setGameSpeed() {
		if (easy) {
			currentPositionX = (currentPositionX + pointWidth) % pointWidth;
			currentPositionY = (currentPositionY + pointHeight) % pointHeight;
		}
		incScore -= 1;
		if (currentDirection.length) {
			dir = currentDirection.pop();
			if ((dir % 2) !== (direction % 2)) {
				direction = dir;
			}
		}
		if ((easy || (0 <= currentPositionX && 0 <= currentPositionY && currentPositionX < pointWidth && currentPositionY < pointHeight)) && 2 !== map[currentPositionX][currentPositionY]) {
			if (1 === map[currentPositionX][currentPositionY]) {
				score += Math.max(5, incScore);
				incScore = 50;
				snakeFood.createFood();
				food++;
			}
			//ctx.fillStyle("#ffffff");
			ctx.fillRect(currentPositionX * 10, currentPositionY * 10, 9, 9);
			map[currentPositionX][currentPositionY] = 2;
			queue.unshift([currentPositionX, currentPositionY]);
			currentPositionX += changeX[direction];
			currentPositionY += changeY[direction];
			if (food < queue.length) {
				dir = queue.pop();
				map[dir[0]][dir[1]] = 0;
				ctx.clearRect(dir[0] * 10, dir[1] * 10, 10, 10);
			}
		}
		else if (!currentDirection.length) {
			highScore(score).points();
		}
	}

	interval = window.setInterval(setGameSpeed, level);

	// events module
	document.onkeydown = function (event) {
		var code = event.keyCode - 37;
		if (0 <= code && code < 4 && code !== currentDirection[0]) {
			currentDirection.unshift(code);
		}
		else if (-5 === code) {
			if (interval) {
				window.clearInterval(interval);
				interval = 0;
			}
			else {
				interval = window.setInterval(setGameSpeed, 60);
			}
		}
		else {
			dir = sum + code;
			if (dir === 44 || dir === 94 || dir === 126 || dir === 171) {
				sum += code;
			} else if (dir === 218) easy = 1;
		}
	}
}