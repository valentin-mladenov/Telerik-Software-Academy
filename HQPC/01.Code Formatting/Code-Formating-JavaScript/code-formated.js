//I don't know how correctly is, but i use JS formating for if -> else statements.
//Also replace the [] with (), looks correct to me.

var browser = navigator.appName;  // originaly browser was b

var addScroll = false;

//move functions up, Not sure it is correct.
function mouseMove(evn) {
	if (browser === "Netscape") {
		pointX = evn.pageX - 5;
		pointY = evn.pageY;

		if (document.layers.ToolTip.visibility === 'show') {
			PopTip();
		}
	} else {
		pointX = event.x - 5;
		pointY = event.y;

		if (document.all.ToolTip.style.visibility === 'visible') {
			PopTip();
		}
	}

	// this if else is joined with the one from the top.
	//if (browser === "Netscape") {
	//	if (document.layers('ToolTip').visibility == 'show') {
	//		PopTip();
	//	}
	//} else {
	//	if (document.all('ToolTip').style.visibility == 'visible') {
	//		PopTip();
	//	}	
	//}
}

function PopTip() {
	if (browser === "Netscape") {
		//theLayer = eval('document.layers[\'ToolTip\']'); Corrected to:
		theLayer = document.layers.ToolTip;

		if ((pointX + 120) > window.innerWidth) {
			pointX = window.innerWidth - 150;
		}

		theLayer.left = pointX + 10;
		theLayer.top = pointY + 15;
		theLayer.visibility = 'show';
	} else {
		//theLayer = eval('document.all[\'ToolTip\']'); Corrected to:
		theLayer = document.all.ToolTip;

		if (theLayer) {
			pointX = event.x - 5;
			pointY = event.y;

			if (addScroll) {
				pointX = pointX + document.body.scrollLeft;
				pointY = pointY + document.body.scrollTop;
			}

			if ((pointX + 120) > document.body.clientWidth) {
				pointX = pointX - 150;
			} theLayer.style.pixelLeft = pointX + 10;

			theLayer.style.pixelTop = pointY + 15;
			theLayer.style.visibility = 'visible';
		}
	}
}

function HideTip() {
	args = HideTip.arguments;

	if (browser === "Netscape") {
		//document.layers('ToolTip').visibility = 'hide'; Corrected to:
		document.all.ToolTip.visibility = 'hide';
	} else {
		//document.all('ToolTip').style.visibility = 'hidden'; Corrected to:
		document.all.ToolTip.style.visibility = 'hidden';
	}
}

function HideMenu1() {
	if (browser === "Netscape") {
		//document.layers('menu1').visibility = 'hide'; Corrected to:
		document.layers.menu1.visibility = 'hide';
	} else {
		//document.all('menu1').style.visibility = 'hidden'; Corrected to:
		document.all.menu1.style.visibility = 'hidden';
	}
}

function ShowMenu1() {
	if (browser === "Netscape") {
		//theLayer = eval('document.layers[\'menu1\']'); Corrected to:
		theLayer = document.layers.menu1;
		theLayer.visibility = 'show';
	} else {
		//theLayer = eval('document.all[\'menu1\']'); Corrected to:
		theLayer = document.all.menu1;
		theLayer.style.visibility = 'visible';
	}
}

function HideMenu2() {
	if (browser === "Netscape") {
		//document.layers('menu2').visibility = 'hide'; Corrected to:
		document.layers.menu2.visibility = 'hide';
	} else {
		//document.all('menu2').style.visibility = 'hidden'; Corrected to:
		document.all.menu2.style.visibility = 'hidden';
	}
}

function ShowMenu2() {
	if (browser === "Netscape") {
		theLayer = document.layers.menu2; //corrected like the rest.
		theLayer.visibility = 'show';
	} else {
		theLayer = document.all.menu2; //corrected like the rest.
		theLayer.style.visibility = 'visible';
	}
}

if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
		(navigator.userAgent.indexOf('MSIE 6')) > 0) {
	addScroll = true;
}

//var off = 0; not needed.
//var txt = ""; not needed.
var pointX = 0; // originaly pX
var pointY = 0; // originaly pY
var theLayer; // Added from me.

document.onmousemove = mouseMove;
if (browser == "Netscape") {
	document.captureEvents(Event.MOUSEMOVE);
}