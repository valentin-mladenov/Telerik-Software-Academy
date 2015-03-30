var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var Mamal = (function (_super) {
        __extends(Mamal, _super);
        function Mamal(legs, hasTail, sex, diet, hasFur, hasHorns) {
            _super.call(this, legs, hasTail, sex, diet);
            this._hasFur = hasFur;
            this._hasHorns = hasHorns;
        }
        Mamal.prototype.sound = function () {
            var fur, horns;

            if (this._hasFur) {
                fur = 'i have fur';
            } else {
                fur = "don't have fur";
            }

            if (this._hasHorns) {
                horns = 'i have horns';
            } else {
                horns = "don't have horns";
            }

            return _super.prototype.sound.call(this) + ',also ' + fur + ' and ' + horns + '.';
        };
        return Mamal;
    })(Animals.Animal);
    Animals.Mamal = Mamal;
})(Animals || (Animals = {}));
//# sourceMappingURL=Mamal.js.map
