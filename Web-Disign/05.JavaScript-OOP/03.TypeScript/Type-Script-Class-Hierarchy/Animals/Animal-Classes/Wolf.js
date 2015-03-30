var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var Wolf = (function (_super) {
        __extends(Wolf, _super);
        function Wolf(sex, diet, legs, hasTail, hasFur, hasHorns) {
            if (typeof diet === "undefined") { diet = 2 /* Carnivore */; }
            if (typeof legs === "undefined") { legs = 4; }
            if (typeof hasTail === "undefined") { hasTail = true; }
            if (typeof hasFur === "undefined") { hasFur = true; }
            if (typeof hasHorns === "undefined") { hasHorns = false; }
            _super.call(this, legs, hasTail, sex, diet, hasFur, hasHorns);
        }
        Wolf.prototype.sound = function () {
            return _super.prototype.sound.call(this) + ' Wolf.';
        };
        return Wolf;
    })(Animals.Mamal);
    Animals.Wolf = Wolf;
})(Animals || (Animals = {}));
//# sourceMappingURL=Wolf.js.map
