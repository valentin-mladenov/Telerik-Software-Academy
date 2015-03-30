module Animals {
	export interface IAnimal {
		_legs: number;
		_hasTail: boolean;
		sound(): string;
	}
}