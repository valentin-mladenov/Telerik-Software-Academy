module World {
	import animalWorld = Animals;
	import collection = Collections;

	export class Forest {
		private animals: collection.List<Animals.IAnimal>;

		constructor() {
			this.animals = new Collections.List<Animals.Animal>();
		}

		public Hunt() {
			for (var i = 0, len = this.animals.count; i < len; i += 1) {
				if (this.animals[i].Diet == "Carnivore") {
					var isHerbNext;

					if (this.animals[i + 1].Diet.Herbivore == true) {
						if (this.animals[i + 1].health < 0) {
							isHerbNext = true;
							this.animals[i + 1].remove();
						} else {
							this.animals[i + 1].health -= 20;
						}
					}
					if (isHerbNext || this.animals[i - 1].Diet.Herbivore == true) {
						if (this.animals[i - 1].health < 0) {
							this.animals[i - 1].remove();
						} else {
							this.animals[i - 1].health -= 20;
						}
					}
				}
			}
		}
	}
} 