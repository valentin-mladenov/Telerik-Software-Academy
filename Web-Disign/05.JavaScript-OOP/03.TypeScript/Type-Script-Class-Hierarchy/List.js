var Collections;
(function (Collections) {
    var List = (function () {
        function List() {
            this._collection = [];
        }
        List.prototype.add = function (item) {
            this._collection.push(item);
        };

        List.prototype.remove = function (item) {
            var itemRemoveIndex = this._collection.indexOf(item);
            var bufer;

            if (itemRemoveIndex < 0) {
                throw new Error('Not such item.');
            }

            //bufer = this._collection[itemRemoveIndex];
            this._collection[itemRemoveIndex] = this._collection[this._collection.length - 1];
        };

        Object.defineProperty(List.prototype, "count", {
            get: function () {
                return this._collection.length;
            },
            enumerable: true,
            configurable: true
        });
        return List;
    })();
    Collections.List = List;
})(Collections || (Collections = {}));
//# sourceMappingURL=List.js.map
