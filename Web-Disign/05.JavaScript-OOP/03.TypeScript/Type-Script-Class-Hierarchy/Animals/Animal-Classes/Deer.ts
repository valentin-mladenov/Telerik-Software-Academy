module Animals {
	export class Deer extends Mamal {
		constructor(sex: Sex, diet: Diet = Diet.Herbivore, legs: number = 4, hasTail: boolean = true,
			hasFur: boolean = true, hasHorns :boolean = true) {
			super(legs, hasTail, sex, diet, hasFur, hasHorns);
		}

		sound(): string {
			return super.sound() + ' Deer.';
		}
	}
}