window.onload = function(){
	"use strict"

	var root = document.getElementById('root');

	// create main DOM
	function formCreator() {
		
		var textArea = document.createElement('textarea'),
			btnAddItem = document.createElement('input'),
			btnDeleteItem = document.createElement('input'),
			btnShowHide = document.createElement('input'),
			rootFragment = document.createDocumentFragment();


		btnAddItem.type = 'button';
		btnAddItem.id = 'add-item';
		btnAddItem.value = 'Add';
		btnDeleteItem.type = 'button';
		btnDeleteItem.id = 'delete-item';
		btnDeleteItem.value = 'Delete';
		btnShowHide.type = 'button';
		btnShowHide.id = 'show-hide';
		btnShowHide.value = 'Show/Hide';
		textArea.id = 'text-area';

		rootFragment.appendChild(textArea);
		rootFragment.appendChild(btnAddItem);
		rootFragment.appendChild(btnDeleteItem);
		rootFragment.appendChild(btnShowHide);

		root.appendChild(rootFragment);
	}
	
	// manipulate DOM
	function InputControlerTODO() {
		var btnAdd = document.getElementById('add-item'),
			btnDelete = document.getElementById('delete-item'),
			btnShowHide = document.getElementById('show-hide'),
			toDoContainer = document.createElement('ul');

		btnAdd.addEventListener('click', function (ev) {
			var toDoAdd = document.createElement('li'),
				textArea = document.getElementById('text-area').value;

			toDoAdd.innerHTML = textArea;

			toDoContainer.appendChild(toDoAdd);
		});

		btnDelete.addEventListener('click', function (ev) {
			var	currentLiElements = toDoContainer.getElementsByTagName('li'),
				liLength = currentLiElements.length,
				itemToDelete = document.getElementById('text-area').value;

			for (var i = 0; i < liLength; i+=1) {
				if (currentLiElements[i].innerHTML === itemToDelete) {
					toDoContainer.removeChild(currentLiElements[i]);
					break;
				}
			}
		});

		btnShowHide.addEventListener('click', function (ev) {
			var currentLiElements = toDoContainer.getElementsByTagName('li'),
				liLength = currentLiElements.length,
				itemToShowHide = document.getElementById('text-area').value;

			for (var i = 0; i < liLength; i += 1) {
				if (currentLiElements[i].innerHTML === itemToShowHide) {

					if (currentLiElements[i].style.display === 'none') {
						currentLiElements[i].style.display = 'block';
						break;
					} else {
						currentLiElements[i].style.display = 'none';
						break;
					}
				}
			}
		})

		root.appendChild(toDoContainer);
	}

	formCreator();
	InputControlerTODO();
};