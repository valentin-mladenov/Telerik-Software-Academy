(function () {
	'use strict';

	var specialConsole = (function() {

		function writeLine() {

			var message = arguments[0];

			for (var i = 0, len = arguments.length - 1; i < len; i++) {
				message = message.replace('{' + i + '}', arguments[i + 1]);
			}
			console.log(message);
		}

		function writeError() {
			writeLine.apply(null,arguments);
		}

		function writeWarning() {
			writeLine.apply(null, arguments);
		}

		return {
			writeLine: writeLine,
			writeError: writeError,
			writeWarning: writeWarning
		}
	}());

	specialConsole.writeLine("Message: hello");
	specialConsole.writeLine("Message: {0}", "hello");
	specialConsole.writeError("Error: {0} {1}", "Something","happened");
	specialConsole.writeError("Error: Something else happened");
	specialConsole.writeWarning("Warning: {0}", "A warning");
	specialConsole.writeWarning("Warning: Some warning");
	specialConsole.writeWarning("Warning: {0} {1} {2}", "Some","other","warning");
}());