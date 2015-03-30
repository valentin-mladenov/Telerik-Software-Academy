define(["jquery", "handlebars"], function($) {
	var isClicked = false;

	$('#root').on('click', function(ev) {
		var $this = $(this);
		var $allOptions = $this.children('.person-item'),
			len = $allOptions.length,
			i;

		if (isClicked == false) {
			for (i = 0; i < len; i += 1) {
				$($allOptions[i]).hide();
			}
			$(ev.target.parentNode).show();

			isClicked = !isClicked;
		} else {
			for (i = 0; i < len; i += 1) {
				$($allOptions[i]).show();
			}
			isClicked = !isClicked;
		}
	});
});