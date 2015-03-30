// Make no mistake, i had vastly helped by internet. Most from my code is created by someone else,
// teoreticly all of it, but i make some of it myself, before find what i need.
// I personaly dislike RegEx-es, but i think in this case they are usable.

//for more use Sizzle https://github.com/jquery/sizzle/blob/master/sizzle.js

(function () {
	'use strict';

	function querySelectorAll(selector) {
		if (/^[\w-]+$/.test(selector)) {
			return toArray(document.getElementsByTagName(selector));
		} else if (/^#[\w-]+$/.test(selector)) {
			var allChars = toArray(document.getElementsByTagName('*')),
				className = selector.slice(1),
				pattern = new RegExp('\\b' + className + '\\b');

			return allChars.filter(function (item) {
				return pattern.test(item.className);
			});
		}
	}

	if (typeof document.querySelectorAll !== 'function') {
		document.querySelectorAll = querySelectorAll;
	}

	document.querySelectorAllShim = querySelectorAll;

	function querySelector(selector) {
		return querySelectorAll(selector)[0];
	}

	if (typeof document.querySelectorAll !== 'function') {
		document.querySelectorAll = querySelectorAll;
	}

	document.querySelectorShim = querySelector;

	var selectors = ['div', '#content', '.inner', '.nonexistent'];

	selectors.forEach(function (selector) {
		console.group('Élements matching selector:', selector);
		console.log('querySelectorAll:', document.querySelectorAllShim(selector));
		console.log('querySelector:', document.querySelectorShim(selector));
		console.groupEnd();
	});

	function toArray(list) {
		return Array.prototype.slice.call(list || []);
	}
}) ();