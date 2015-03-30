var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var Deer = (function (_super) {
        __extends(Deer, _super);
        function Deer(sex, diet, legs, hasTail, hasFur, hasHorns) {
            if (typeof diet === "undefined") { diet = 1 /* Herbivore */; }
            if (typeof legs === "undefined") { legs = 4; }
            if (typeof hasTail === "undefined") { hasTail = true; }
            if (typeof hasFur === "undefined") { hasFur = true; }
            if (typeof hasHorns === "undefined") { hasHorns = true; }
            _super.call(this, legs, hasTail, sex, diet, hasFur, hasHorns);
        }
        Deer.prototype.sound = function () {
            return _super.prototype.sound.call(this) + ' Deer.';
        };
        return Deer;
    })(Animals.Mamal);
    Animals.Deer = Deer;
})(Animals || (Animals = {}));
//# sourceMappingURL=Deer.js.map
