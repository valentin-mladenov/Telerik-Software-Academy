(function() {
	'use strict';

	var domModule = (function () {
		var BUFFER_MAX_COUNT = 100;
		var buffer = [];

		function appendChild(childSelector, parentSelector) {
			var parent = document.querySelector(parentSelector);

			parent.appendChild(childSelector);
		}

		function removeChild(parentType, childSelector) {
			var parent = document.querySelector(parentType),
				child = document.querySelector(childSelector);

			parent.removeChild(child);
		}

		function addHandler(handlerSelector, action, funcToExecute) {
			var element = document.querySelector(handlerSelector);

			element.addEventListener(action, funcToExecute);
		}

		function appendToBuffer(parentSelector, childSelector) {
			var inner, i;

			buffer.push({
				parentSelector: parentSelector,
				childSelector: childSelector
			});

			if (buffer.length == BUFFER_MAX_COUNT) {

				for (i = 0; i < BUFFER_MAX_COUNT; i += 1) {
					inner = buffer.pop();
					
					if (BUFFER_MAX_COUNT - 1 ==i) {
						var a = document.createElement("a");
						a.innerHTML = 'buffer rached';
						inner.childSelector.appendChild(a);
					}

					appendChild(inner.childSelector, inner.parentSelector);
				}
			}

		}

		return {
			appendChild: appendChild,
			removeChild: removeChild,
			addHandler: addHandler,
			appendToBuffer: appendToBuffer
		}
	}());

	var div = document.createElement("div"),
		p = document.createElement("p"),
		ol = document.createElement("ol"),
		navItem = document.createElement('li');

	domModule.appendChild(div, '#wrapper');
	domModule.appendChild(p, 'div');
	domModule.appendChild(ol, 'div.marmalad');
	domModule.removeChild("ul", "li:first-child");

	domModule.addHandler("a.button", 'click',
                     function () { alert("Clicked"); });

	for (var i = 0; i < 101; i+=1) {
		domModule.appendToBuffer(".container", div.cloneNode(true));
		domModule.appendToBuffer("#main-nav ul", navItem.cloneNode(true));
	}
}());