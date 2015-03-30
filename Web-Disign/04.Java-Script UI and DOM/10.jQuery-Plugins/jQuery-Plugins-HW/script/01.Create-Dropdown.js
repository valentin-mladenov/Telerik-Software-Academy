/// <reference path="_references.js" />

(function ($) {
	$.fn.dropdown = function () {
		var $this = $(this).hide(),
			$options = $this.find('option'),
			$root = $('#root'),
			$dropdownListContainer  = $('<div />'),
			$dropdownUlOptions = $('<ul />'),
			$dropdownListOption = $('<li/>');

		$dropdownListContainer.addClass('dropdown-list-container');
		$dropdownUlOptions.addClass('dropdown-list-options');
		$dropdownListOption.addClass('dropdown-list-option');

		for (var i = 0, len = $options.length; i < len; i+=1) {
			var optionHTML = $($options[i]).html();

			$dropdownListOption.data('data-value', i);
			$dropdownListOption.html(optionHTML);

			$dropdownListOption.clone(true).appendTo($dropdownUlOptions);
		}

		$dropdownUlOptions.appendTo($dropdownListContainer);

		$this.after($dropdownListContainer);

		var isClicked = false;

		$('.dropdown-list-option').on('click', function () {
			var $this = $(this);
			var $allOptions = $('.dropdown-list-option'),
				len = $allOptions.length;

			if (isClicked == false) {			
				for (var i = 0; i < len; i+=1) {
					$($allOptions[i]).hide();
				}
				$this.show();

				isClicked = !isClicked;
			} else {
				for (var i = 0; i < len; i += 1) {
					$($allOptions[i]).show();
				}
				isClicked = !isClicked;
			}
		});
	};
}(jQuery));