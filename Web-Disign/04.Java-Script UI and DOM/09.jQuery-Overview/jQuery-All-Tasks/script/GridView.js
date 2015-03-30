window.onload = function () {

	$('#root').append(generateGridView());

	function generateGridView() {
		var $gridview = $('<div/>'),
			hasHeader = false,

			$table = $('<table/>'),
			$row = $('<tr/>'),
			$cell = $('<td/>'),
			$header = $('<th/>'),

			$firstCellContent = $('<input />').attr('placeholder', 'Enter cell content').attr('type', 'text'),
			$secondCellContent = $firstCellContent.clone(true),
			$thirdCellContent = $firstCellContent.clone(true),
			$addRowBtn = $('<a/>').attr('href', '#').html('Add row');

		$addRowBtn.addClass('button');
		var $addHeaderBtn = $addRowBtn.clone(true).html('Add header'),
			$removeHeaderBtn = $addRowBtn.clone(true).html('Remove header'),
			$addGridBtn = $addRowBtn.clone(true).html('Add gridview');

		$gridview.addClass('gridview')
		.append($firstCellContent)
		.append($secondCellContent)
		.append($thirdCellContent)
		.append($addRowBtn)
		.append($addHeaderBtn)
		.append($removeHeaderBtn)
		.append($addGridBtn)
		.append($table);

		$gridview.on('click', '> .button:first-of-type', function () {
			debugger;
			var $this = $(this).parent(),
				$newRow = $row.clone(true),
				$cells = $this.find('> input');

			for (var i = 0, len = $cells.length; i < len; i++) {
				var $newCell = $cell.clone(true),
					content = $cells[i].value;

				if (content === '') {
					content = '&nbsp;'
				}

				$newCell.html(content);
				$newRow.append($newCell);
			}

			$this.find('> table:first-of-type').append($newRow);
		});

		$gridview.on('click', '> .button:nth-of-type(2)', function () {
			if (hasHeader) {
				return;
			}

			var $this = $(this).parent(),
				$firstRow = $row.clone(true),
				$cells = $this.find('> input');


			for (var i = 0, len = $cells.length; i < len; i++) {
				var $newHeader = $header.clone(true),
					content = $cells[i].value;

				if (content === '') {
					content = '&nbsp;'
				}

				$newHeader.append(content);
				$firstRow.append($newHeader);
			}

			$this.find('> table:first-of-type').prepend($firstRow);
			hasHeader = true;
		});

		$gridview.on('click', '> .button:nth-of-type(3)', function () {
			var $this = $(this).parent();

			if (hasHeader) {
				$this.find('> table:first-of-type').find('tr:first-child').remove();
				hasHeader = false;
			}
		});

		$gridview.on('click', '> .button:last-of-type', function () {
			var $this = $(this).parent(),
				$newRow = $row.clone(true),
				$newCell = $cell.clone(true),
				$newGrid = generateGridView();

			$newCell.html($newGrid[0]).attr('colspan', 3);
			$newRow.append($newCell);
			$this.find('> table:first-of-type').append($newRow);
		});

		return $gridview;
	};
}