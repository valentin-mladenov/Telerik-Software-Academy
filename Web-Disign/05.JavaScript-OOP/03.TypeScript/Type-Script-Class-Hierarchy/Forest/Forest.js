var World;
(function (World) {
    var Forest = (function () {
        function Forest() {
            this.animals = new Collections.List();
        }
        Forest.prototype.Hunt = function () {
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
        };
        return Forest;
    })();
    World.Forest = Forest;
})(World || (World = {}));
//# sourceMappingURL=Forest.js.map
