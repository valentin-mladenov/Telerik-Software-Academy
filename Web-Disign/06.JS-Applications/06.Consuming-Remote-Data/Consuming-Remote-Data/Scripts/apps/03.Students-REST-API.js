require(['jQurey', 'HTTPRequester'], function () {
	'use strict';

	var $errorMessage,
		$successMessage,
		addStudent,
		reloadStudents,
		removeStudent,
		deleteUrl,
		resourceUrl;

	resourceUrl = 'http://localhost:3000/students';
	deleteUrl = 'http://localhost:3000/students';
	$successMessage = $('.messages .success');

	$errorMessage = $('.messages .error');

	addStudent = function (data) {
		return $.ajax({
			url: resourceUrl,
			type: 'POST',
			data: JSON.stringify(data),
			contentType: 'application/json',
			success: function (data) {
				$successMessage
				  .html('' + data.name + ' successfully added')
				  .show()
				  .fadeOut(2000);
				reloadStudents();
			},
			error: function (err) {
				$errorMessage
				  .html('Error happened: ' + err)
				  .show()
				  .fadeOut(2000);
			}
		});
	};

	reloadStudents = function () {
		$.ajax({
			url: resourceUrl,
			type: 'GET',
			contentType: 'application/json',
			success: function (data) {
				var student, $studentsList, i, len;
				$studentsList = $('<ul/>').addClass('students-list');
				for (i = 0, len = data.students.length; i < len; i++) {
					student = data.students[i];
					$('<li />')
					  .addClass('student-item')
					  .append($('<strong /> ')
						.html('Name: '+student.name))
					  .append($('<span />')
						.html(' , Garde: '+student.grade))
					  .appendTo($studentsList);
				}
				$('#students-container').html($studentsList);
			},
			error: function () {
				$errorMessage
				  .html("Error happened: " + err)
				  .show()
				  .fadeOut(2000);
			}
		});
	};

	$(function () {
		reloadStudents();
		$('#btn-add-student').on('click', function () {
			var student;
			student = {
				name: $('#tb-name').val(),
				grade: $('#tb-grade').val()
			};
			addStudent(student);
		});

		$('#btn-remove-student').on('click', function() {
			var id;
			id = $('#tb-id').val();
			console.log(id);
			removeStudent(id);
		});
	});

	removeStudent = function (id) {
		console.log(id);
		return $.ajax({
			url: resourceUrl + '/' + id.toString(),
			type: 'POST',
			id: id,
			data: {	_method: 'delete' },
			timeout: 2000,
			success: function (data) {
				console.log(data);
				$successMessage
				  .html(data.message)
				  .show()
				  .fadeOut(2000);
				reloadStudents();
			},
			error: function (err) {
				console.log(err);
				$errorMessage
				  .html('Error happened: ' + err)
				  .show()
				  .fadeOut(2000);
			}
		});
	};

}).call(this);

//# sourceMappingURL=scripts.map