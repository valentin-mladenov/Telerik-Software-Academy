 module Animals {
	 export enum Diet { Omnivore, Herbivore, Carnivore };

	 export enum Sex {Male, Female};

	 export class Animal implements IAnimal {
		 _legs: number;
		 _hasTail: boolean;
		 _sex: Sex;
		 _diet: Diet;
		 static health: number;

		 constructor(legs: number, hasTail: boolean, sex: Sex, diet: Diet) {
			 this._legs = legs;
			 this._hasTail = hasTail;
			 this._sex = sex;
			 this._diet = diet;
		 }

		 get Sex() {
			 return this._sex;
		 }

		 get Diet() {
			 return this._diet;
		 }

		 get legs() {
			 return this._legs;
		 }

		 get hasTail() {
			 return this._hasTail;
		 }

		 sound(): string {
			 return 'I have ' + this._legs + " legs, i'm " + this._sex +
				 ' and my diet is ' + this._diet;
		 }
	 }
 }