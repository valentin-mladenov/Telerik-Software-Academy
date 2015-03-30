var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var Aligator = (function (_super) {
        __extends(Aligator, _super);
        function Aligator(sex, diet, legs, hasTail, isVenomous) {
            if (typeof diet === "undefined") { diet = 2 /* Carnivore */; }
            if (typeof legs === "undefined") { legs = 4; }
            if (typeof hasTail === "undefined") { hasTail = true; }
            if (typeof isVenomous === "undefined") { isVenomous = false; }
            _super.call(this, legs, hasTail, sex, diet, isVenomous);
        }
        Aligator.prototype.sound = function () {
            return _super.prototype.sound.call(this) + ' Aligator.';
        };
        return Aligator;
    })(Animals.Reptile);
    Animals.Aligator = Aligator;
})(Animals || (Animals = {}));
//# sourceMappingURL=Aligator.js.map
