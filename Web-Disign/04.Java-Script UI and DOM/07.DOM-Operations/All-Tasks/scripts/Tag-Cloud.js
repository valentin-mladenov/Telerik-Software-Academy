window.onload = function () {
	"use strict"

	var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net",
		".net", "css", "wordpress", "xaml", "js", "http", "web",
		"asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript",
		"js", "cms", "html", "javascript", "http", "http", "CMS"],
		minFontSize = 17,
		maxFontSize = 42,
			i,j;

	function sortTags(array) {
		var isInArray = false, 
			sorted =[],
			len = array.length;

		for (i = 0; i < len; i+=1) {
			
			for (j = 0; j < sorted.length; j+=1) {
				if(array[i].toLowerCase() == sorted[j].tag){
					var mediumFontSize = (maxFontSize - minFontSize) / 2;
					sorted[j].count += 1;
					if (sorted[j].count === 2) {
						sorted[j].fontSize = mediumFontSize;
					} else {
						sorted[j].fontSize = maxFontSize;
					}
					isInArray = true;
					break;
				}
			}

			if (!isInArray) {
				sorted.push({
					tag: array[i].toLowerCase(),
					count: 1,
					fontSize: minFontSize
				});
			}
			isInArray = false;
		}

		return sorted;
	}

	function generateTagCloud(tags,minFontSize,maxFontSize) {
		
		var tagsAndCount = [],
			root = document.getElementById('root'),
			tagArea = document.createElement('div'),
			rootFragment = document.createDocumentFragment();

		tagsAndCount = sortTags(tags);
		var tagLength = tagsAndCount.length;

		for (i = 0; i < tagLength; i+=1) {
			var currTag = document.createElement('span');
			currTag.innerHTML = tagsAndCount[i].tag+' ';
			currTag.style.fontSize = tagsAndCount[i].fontSize+'px';

			tagArea.appendChild(currTag);
		}

		tagArea.style.width = '200px';

		rootFragment.appendChild(tagArea);

		root.appendChild(rootFragment);
	}
	generateTagCloud(tags,minFontSize,maxFontSize);

};