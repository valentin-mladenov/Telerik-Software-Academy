module Collections {
	export class List<T> {
		private _collection: T[];

		constructor() {
			this._collection = [];
		}

		add(item: T) :void{
			this._collection.push(item);
		}

		remove(item: T) :void{
			var itemRemoveIndex = this._collection.indexOf(item);
			var bufer;

			if (itemRemoveIndex < 0) {
				throw new Error('Not such item.');
			}

			//bufer = this._collection[itemRemoveIndex];
			this._collection[itemRemoveIndex] = this._collection[this._collection.length - 1];
		}

		get count() {
			return this._collection.length;
		}
	}
} 