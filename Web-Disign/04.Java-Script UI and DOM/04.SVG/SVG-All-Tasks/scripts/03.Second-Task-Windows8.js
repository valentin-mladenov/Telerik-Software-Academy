

function createText(posX, posY, content, fillColor, fontSize, fontFamily, fontWeight) {
	if (fontSize == undefined) {
		fontSize = 13;
	}

	if (fontFamily == undefined) {
		fontFamily = "Consolas";
	}

	if (fontWeight == undefined) {
		fontWeight = "normal";
	}

	if (fillColor == undefined) {
		fillColor = "#fff";
	}

	var text = '<text x="';
	text += posX;
	text += '" y="';
	text += posY;
	text += '" fill="';
	text += fillColor;
	text += '" font-size="';
	text += fontSize;
	text += 'px" font-weight="';
	text += fontWeight;
	text += '" font-family="';
	text += fontFamily;
	text += '" >';
	text += content;
	text += '</text>';

	return text;
}

function createRect(posX, posY, width, height, fillColor) {
	var rect = '<rect x="';
	rect += posX;
	rect += '" y="';
	rect += posY;
	rect += '" width="';
	rect += width;
	rect += '" height="';
	rect += height;
	rect += '" style="fill:';
	rect += fillColor;
	rect += ';" />';

	return rect;
}

function addImage(posX, posY, src) {
	var image = '<image xlink:href="';
	image += src;
	image += '" x="'
	image += posX;
	image += '" y="';
	image += posY;
	image += '" height="100px" width="100px"/>';

	return image;
}

function createSmall(posX, posY, color, text, icon) {
	var result = createRect(posX, posY, 100, 100, color);
	result += createText(posX + 10, posY + 90, text);

	if (icon != undefined) {
		result += addImage(posX, posY, icon);
	}

	return result;
}

function createBig(posX, posY, color, text, icon) {
	var result = createRect(posX, posY, 205, 100, color);
	result += createText(posX + 10, posY + 90, text);

	if (icon != undefined) {
		result += addImage(posX + 50, posY, icon);
	}

	return result;
}

