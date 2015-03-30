(function () {
	'use strict';

	//check if running on Node.js
	if (typeof require !== 'undefined') {
		//load underscore if on Node.js
		_ = require('../../scripts/underscore.js');
	}

	var Book;

	Book = (function () {

		function Book(name, author) {
			this._name = name;
			this._author = author;

			return {
				Name: this._name,
				Author: this._author
			};
		}

		return Book;
	})();

	var books = [
		new Book('Asya', 'Ivan Turgenev'),
		new Book('Under The Yoke', 'Ivan Vazov'),
		new Book('Macbeth', 'William Shakespeare'),
		new Book('Child of Time', 'Isaac Asimov'),
		new Book('New Earth', 'Ivan Vazov'),
		new Book('Othello', 'William Shakespeare'),
		new Book('Barrayar', 'Lois McMaster Bujold'),
		new Book('Svetoslav Terter', 'Ivan Vazov'),
		new Book('The End of Eternity', 'Isaac Asimov'),
		new Book('Rudin', 'Ivan Turgenev')
	];

	var mostFrequentAuthor;

	//I'm stuned from this chain?!?!
	mostFrequentAuthor = _.chain(books)
		.countBy('Author')
		.pairs()
		.max(_.last)
		.head()
		.value();

	console.log('Most popular author: ' + mostFrequentAuthor);
})();