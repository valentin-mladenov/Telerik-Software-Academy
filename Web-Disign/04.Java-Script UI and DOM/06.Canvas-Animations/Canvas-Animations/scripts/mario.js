

function mario() {
	var stage = new Kinetic.Stage({
		container: 'container',
		width: 1000,
		height: 620
	});

	var layer = new Kinetic.Layer();

	var imageObj = new Image();

	imageObj.onload = function () {
		var mario = new Kinetic.Sprite({
			x: 380,
			y: 490,
			image: imageObj,
			animation: 'idle',
			animations: {
				idle: [
				688, 155, 88, 119
				],
				move: [
				7, 290, 80, 119,
				90, 290, 80, 119,
				170, 290, 80, 119,
				250, 290, 80, 119,
				330, 290, 80, 119,
				416, 290, 80, 119,
				490, 290, 80, 119
				]
			},
			frameRate: 7,
			frameIndex: 0
		});

		layer.add(mario);
		stage.add(layer);

		mario.start();

		var frameCount = 0;

		mario.on('frameIndexChange', function (evt) {
			if (mario.animation() == 'move' && ++frameCount > 7) {
				mario.animation('idle');
				mario.scaleX(1);
				frameCount = 0;
			}
		});

		window.addEventListener('keydown', onKeyDown);
		var el = document.getElementsByTagName("canvas")[0];
		el.addEventListener("touchstart", handleStart, false);

		// Moving
		function moveLeft() {
			mario.setX(mario.attrs.x -= 50);
			mario.scaleX(-1);
			mario.attrs.animation = 'move';
		}

		function moveRight() {
			mario.setX(mario.attrs.x += 50);
			mario.scaleX(1);
			mario.attrs.animation = 'move';
		}

		function stop(pos) {
			mario.setX(mario.attrs.x = pos);
			mario.animation('idle');
			mario.scaleX(1);
			frameCount = 0;
		}

		// Keyboard moving
		function onKeyDown(evt) {
			switch (evt.keyCode) {
				case 37:
					if (mario.attrs.x > 90) {
						moveLeft();
					} else {
						stop(0);
					}
					break;
				case 39:
					if (mario.attrs.x < document.getElementsByTagName('canvas')[0].width - 80) {
						moveRight();
					} else {
						stop(document.getElementsByTagName('canvas')[0].width - 80);
					}
					break;
			}
		}

		// Mouse moving
		$('canvas').click(function (evt) {
			move(evt);
		});

		// Touch moving
		function handleStart(evt) {
			move(evt)
		}

		function move(evt) {
			var timeout = $(this).data("timeout");
			if (timeout) clearTimeout(timeout);
			$(this).data('timeout', window.setInterval(function () {
				if (Math.abs(evt.clientX - mario.attrs.x) > 30) {
					if (mario.attrs.x > evt.clientX) {
						moveLeft();
					} else {
						moveRight();
					}
				}
			}, 100));
		}

	};

	imageObj.src = 'images/sprite.png';
}