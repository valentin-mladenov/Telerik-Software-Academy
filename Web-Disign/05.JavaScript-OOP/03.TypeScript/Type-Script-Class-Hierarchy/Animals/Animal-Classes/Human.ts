module Animals {
	export class Human extends Mamal {
		constructor(sex: Sex, diet: Diet = Diet.Omnivore, legs: number = 2,
			hasTail: boolean = false, hasFur: boolean = false, hasHorns: boolean = false) {
			super(legs, hasTail, sex, diet, hasFur, hasHorns);
		}

		sound(): string {
			return super.sound() + ' Human.';
		}
	}
} 