module Animals {
	export class BlackMamba extends Reptile {
		constructor(sex: Sex, diet: Diet = Diet.Carnivore, legs: number = 0, hasTail: boolean = true,
			isVenomous: boolean = true) {
			super(legs, hasTail, sex, diet, isVenomous);
		}

		sound(): string {
			return super.sound() + ' Black Mamba.';
		}
	}
}