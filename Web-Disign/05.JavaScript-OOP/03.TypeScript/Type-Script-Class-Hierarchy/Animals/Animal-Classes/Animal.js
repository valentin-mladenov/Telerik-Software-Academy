var Animals;
(function (Animals) {
    (function (Diet) {
        Diet[Diet["Omnivore"] = 0] = "Omnivore";
        Diet[Diet["Herbivore"] = 1] = "Herbivore";
        Diet[Diet["Carnivore"] = 2] = "Carnivore";
    })(Animals.Diet || (Animals.Diet = {}));
    var Diet = Animals.Diet;
    ;

    (function (Sex) {
        Sex[Sex["Male"] = 0] = "Male";
        Sex[Sex["Female"] = 1] = "Female";
    })(Animals.Sex || (Animals.Sex = {}));
    var Sex = Animals.Sex;
    ;

    var Animal = (function () {
        function Animal(legs, hasTail, sex, diet) {
            this._legs = legs;
            this._hasTail = hasTail;
            this._sex = sex;
            this._diet = diet;
        }
        Object.defineProperty(Animal.prototype, "Sex", {
            get: function () {
                return this._sex;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Animal.prototype, "Diet", {
            get: function () {
                return this._diet;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Animal.prototype, "legs", {
            get: function () {
                return this._legs;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Animal.prototype, "hasTail", {
            get: function () {
                return this._hasTail;
            },
            enumerable: true,
            configurable: true
        });

        Animal.prototype.sound = function () {
            return 'I have ' + this._legs + " legs, i'm " + this._sex + ' and my diet is ' + this._diet;
        };
        return Animal;
    })();
    Animals.Animal = Animal;
})(Animals || (Animals = {}));
//# sourceMappingURL=Animal.js.map
