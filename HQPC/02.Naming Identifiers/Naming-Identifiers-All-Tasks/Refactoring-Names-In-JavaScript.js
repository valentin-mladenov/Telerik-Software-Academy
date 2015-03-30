//Refactor the following examples to produce code with well-named identifiers in JavaScript.
//function _ClickON_TheButton(THE_event, argumenti) {
//	var moqProzorec = window;
//	var brauzyra = moqProzorec.navigator.appCodeName;
//	var ism = brauzyra == "Mozilla";				//varible not needed.
//	if (ism) {
//		alert("Yes");
//	}
//	else {
//		alert("No");
//	}
//}

function onClick(event, arguments) {
	var browser = window.navigator.appCodeName;		//Both var combined from original code.			
	if (browser === "Mozilla") {
		alert("Yes");
	} else {			//else on same row folowing Crockford code convention.
		alert("No");
	}
}