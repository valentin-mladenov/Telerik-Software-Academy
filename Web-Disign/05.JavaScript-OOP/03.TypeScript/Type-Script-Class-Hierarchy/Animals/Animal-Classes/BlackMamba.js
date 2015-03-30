var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var BlackMamba = (function (_super) {
        __extends(BlackMamba, _super);
        function BlackMamba(sex, diet, legs, hasTail, isVenomous) {
            if (typeof diet === "undefined") { diet = 2 /* Carnivore */; }
            if (typeof legs === "undefined") { legs = 0; }
            if (typeof hasTail === "undefined") { hasTail = true; }
            if (typeof isVenomous === "undefined") { isVenomous = true; }
            _super.call(this, legs, hasTail, sex, diet, isVenomous);
        }
        BlackMamba.prototype.sound = function () {
            return _super.prototype.sound.call(this) + ' Black Mamba.';
        };
        return BlackMamba;
    })(Animals.Reptile);
    Animals.BlackMamba = BlackMamba;
})(Animals || (Animals = {}));
//# sourceMappingURL=BlackMamba.js.map
