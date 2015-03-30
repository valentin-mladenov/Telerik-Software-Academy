module Animals {
	export class Wolf extends Mamal {
		constructor(sex: Sex, diet: Diet = Diet.Carnivore, legs: number = 4, hasTail: boolean = true,
			hasFur: boolean = true, hasHorns: boolean = false) {
			super(legs, hasTail, sex, diet, hasFur, hasHorns);
		}

		sound(): string {
			return super.sound() + ' Wolf.';
		}
	}
}