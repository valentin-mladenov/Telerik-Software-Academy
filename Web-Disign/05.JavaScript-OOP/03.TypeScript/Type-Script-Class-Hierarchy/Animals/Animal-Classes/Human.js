var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var Human = (function (_super) {
        __extends(Human, _super);
        function Human(sex, diet, legs, hasTail, hasFur, hasHorns) {
            if (typeof diet === "undefined") { diet = 0 /* Omnivore */; }
            if (typeof legs === "undefined") { legs = 2; }
            if (typeof hasTail === "undefined") { hasTail = false; }
            if (typeof hasFur === "undefined") { hasFur = false; }
            if (typeof hasHorns === "undefined") { hasHorns = false; }
            _super.call(this, legs, hasTail, sex, diet, hasFur, hasHorns);
        }
        Human.prototype.sound = function () {
            return _super.prototype.sound.call(this) + ' Human.';
        };
        return Human;
    })(Animals.Mamal);
    Animals.Human = Human;
})(Animals || (Animals = {}));
//# sourceMappingURL=Human.js.map
