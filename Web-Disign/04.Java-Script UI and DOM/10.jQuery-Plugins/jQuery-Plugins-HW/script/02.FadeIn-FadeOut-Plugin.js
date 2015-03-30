/// <reference path="_references.js" />

(function ($) {
	$.fn.messageBox = function () {
		var $this = $(this);

		$this.hide();
		//$this.css('border', '3px solid black');
		$this.css('border-radius', '20px');
		$this.css('height', '100px');
		$this.css('width', '150px');
		//$this.css('background-color', 'gray');
		$this.css('padding-left', '50px');
		$this.css('padding-top', '50px');
		//$this.css('padding-right', '50px');
		return $this;
	}
	$.fn.success = function (string) {
		$(this).fadeIn(1000)
			.css('border', '3px solid #7f7')
			.css('background-color', '#afa')
			.html(string)
			.css('color', '#97B6E9')
			.css('font-weight', 'bold')
			.css('font-family', 'Consolas')
			.delay(3000)
			.fadeOut(1000);
	};

	$.fn.error = function (string) {
		$(this).fadeIn(1000)
			.css('border', '3px solid black')
			.css('background-color', 'gray')
			.html(string)
			.css('color', 'red')
			.css('font-weight', 'bold')
			.css('font-Family', 'Arial')
			.delay(3000)
			.fadeOut(1000);
	};
}(jQuery));