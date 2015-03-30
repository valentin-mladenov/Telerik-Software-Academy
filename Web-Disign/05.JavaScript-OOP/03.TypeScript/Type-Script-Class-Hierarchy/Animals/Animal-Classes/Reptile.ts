module Animals {

	export class Reptile extends Animal implements IReptile {
		_isVenomous: boolean;

		constructor(legs: number, hasTail: boolean, sex: Sex, diet: Diet,
			isVenomous: boolean) {
			super(legs, hasTail, sex, diet);
			this._isVenomous = isVenomous;
		}

		sound(): string {
			var venomous;

			if (this._isVenomous) {
				venomous = "i'm venomous";
			} else {
				venomous = "i'm not venomous";
			}

			return super.sound() + ',also ' + venomous;
		}
	}
}