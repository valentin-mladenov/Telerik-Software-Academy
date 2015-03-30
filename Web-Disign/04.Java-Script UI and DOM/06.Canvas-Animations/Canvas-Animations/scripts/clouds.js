function clouds(paper) {
	var NUMBER_OF_CLOUDS = 15,
	clouds = [],
	activeClouds = [];

	function makeCloud(cloud_no) {
		var randomY = Math.round(((Math.random() * 180) + 1) * 1000) / 1000;
		var speed = Math.round((Math.random() * 10) + 10) * 1000;
		var size = (Math.random() * 2) + 1;
		var cloud = paper.path("m950," + randomY + "c0.019-0.195,0.03-0.392,0.03-0.591c0-3.452-2.798-6.25-6.25-6.25c-2.679,0-4.958,1.689-5.847,4.059c-0.589-0.646-1.429-1.059-2.372-1.059c-1.778,0-3.219,1.441-3.219,3.219c0,0.21,0.023,0.415,0.062,0.613c-2.372,0.391-4.187,2.436-4.187,4.918c0,2.762,2.239,5,5,5h15.875c2.762,0,5-2.238,5-5C28.438,16.362,26.672,14.332,24.345z").attr({ fill: "#fff", stroke: "#fff" });
		var anim = Raphael.animation(
		{ transform: "t-950,0S" + size },
		speed,
		function () {
			activeClouds[cloud_no] = false;
		});

		if (Math.random() > .5)
			cloud.toFront();
		else
			cloud.toBack();

		cloud.animate(anim);
		return cloud;
	}

	function animationFrame() {
		var j = 0;

		while (j < NUMBER_OF_CLOUDS) {
			if (!activeClouds[j]) {
				clouds[j].remove();
				activeClouds[j] = true;
				clouds[j] = makeCloud(j);
			}

			j = j + 1;
		}
	}

	var i = 0;
	while (i < NUMBER_OF_CLOUDS) {
		activeClouds[i] = true;
		clouds[i] = makeCloud(i);
		i = i + 1;
	}

	setInterval(animationFrame, 500);
}