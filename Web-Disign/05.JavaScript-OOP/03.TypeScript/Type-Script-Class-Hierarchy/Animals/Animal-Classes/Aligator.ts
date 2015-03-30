module Animals {
	export class Aligator extends Reptile {
		constructor(sex: Sex, diet: Diet = Diet.Carnivore, legs: number = 4, hasTail: boolean = true,
			isVenomous: boolean = false) {
			super(legs, hasTail, sex, diet, isVenomous);
		}

		sound(): string {
			return super.sound() + ' Aligator.';
		}
	}
}
