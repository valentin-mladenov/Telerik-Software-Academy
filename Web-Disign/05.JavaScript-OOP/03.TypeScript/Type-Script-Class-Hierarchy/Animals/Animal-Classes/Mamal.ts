module Animals {

	export class Mamal extends Animal implements IMamal {
		 _hasFur: boolean;
		 _hasHorns: boolean;

		constructor(legs: number, hasTail: boolean, sex: Sex, diet: Diet,
			hasFur: boolean, hasHorns: boolean) {
			super(legs, hasTail, sex, diet);
			this._hasFur = hasFur;
			this._hasHorns = hasHorns;
		}

		sound(): string {
			var fur, horns;

			if (this._hasFur) {
				fur = 'i have fur';
			} else {
				fur = "don't have fur";
			}

			if (this._hasHorns) {
				horns = 'i have horns';
			} else {
				horns = "don't have horns";
			}

			return super.sound() + ',also ' + fur + ' and ' + horns + '.';
		}
	}
}