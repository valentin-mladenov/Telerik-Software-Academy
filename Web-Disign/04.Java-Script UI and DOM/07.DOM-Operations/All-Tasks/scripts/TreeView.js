window.onload = function () {
	"use strict"

	var ListContent = 5;

	function generateTreeView() {

		var root = document.getElementById('root'),
			UlMainParent = document.createElement('ul'),
			rootFragment = document.createDocumentFragment();

		for (var i = 0; i < ListContent; i += 1) {
			var innerList = document.createElement('li'),
				firstSubUl = document.createElement('ul'),
				listContent = document.createElement('span');

			listContent.innerHTML = 'Main Item ' + (i + 1).toString();
			innerList.id = 'mainList';
			innerList.appendChild(listContent);
			// innerList.appendChild(firstSubUl);

			for (var j = 0; j < ListContent; j += 1) {
				var subList = document.createElement('li'),
					secondSubUl = document.createElement('ul'),
					subListContent = document.createElement('span');


				subListContent.innerHTML = 'Sub Item ' + (j + 1).toString();
				subList.id = 'subList';
				subList.appendChild(subListContent);
				//subList.style.display = 'none';

				for (var k = 0; k < ListContent; k += 1) {
					var subSubList = document.createElement('li'),
						subSubListContent = document.createElement('span');


					subSubListContent.innerHTML = 'Sub sub Item ' + (k + 1).toString();
					subSubList.id = 'subSubList';
					subSubList.appendChild(subSubListContent);
					//subSubList.style.display = 'none';

					secondSubUl.appendChild(subSubList);
				}

				subList.appendChild(secondSubUl);
				firstSubUl.appendChild(subList);
			}

			innerList.appendChild(firstSubUl);
			UlMainParent.appendChild(innerList);
		}

		rootFragment.appendChild(UlMainParent);
		root.appendChild(rootFragment);
	}

	function displayControler() {
		var mainList = document.getElementById('mainList'),
			subList = document.getElementById('subList'),
			subSubList = document.getElementById('subSubList');

		var allLiElements = document.getElementsByTagName('li');

		for (var i = 0, len = allLiElements.length; i < len; i += 1) {

			var child = allLiElements[i].firstElementChild.nextElementSibling;
			while (child) {
				child.style.display = 'none';
				child = child.nextElementSibling;
			}

			allLiElements[i].addEventListener('click', function (ev) {
				ev.stopPropagation(); // !! Prevent Bubling
				var currentChild = this.firstElementChild.nextElementSibling;
				while (currentChild) {
					if (currentChild.style.display == 'none') {
						currentChild.style.display = 'block';
					} else {
						currentChild.style.display = 'none';
					}

					currentChild = currentChild.nextElementSibling;
				}
			}, false);
		}
	}

	generateTreeView();

	displayControler();
};