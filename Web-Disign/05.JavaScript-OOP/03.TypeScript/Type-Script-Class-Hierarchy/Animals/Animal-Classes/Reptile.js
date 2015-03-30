var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var Reptile = (function (_super) {
        __extends(Reptile, _super);
        function Reptile(legs, hasTail, sex, diet, isVenomous) {
            _super.call(this, legs, hasTail, sex, diet);
            this._isVenomous = isVenomous;
        }
        Reptile.prototype.sound = function () {
            var venomous;

            if (this._isVenomous) {
                venomous = "i'm venomous";
            } else {
                venomous = "i'm not venomous";
            }

            return _super.prototype.sound.call(this) + ',also ' + venomous;
        };
        return Reptile;
    })(Animals.Animal);
    Animals.Reptile = Reptile;
})(Animals || (Animals = {}));
//# sourceMappingURL=Reptile.js.map
