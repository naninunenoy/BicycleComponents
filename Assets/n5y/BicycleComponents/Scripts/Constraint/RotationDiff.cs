using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class RotationDiff {
        readonly IRotator rotator;
        readonly Quaternion DefaultInv;
        public readonly Quaternion Default;
        public Quaternion Current => rotator?.Rotation ?? Quaternion.identity;
        public Quaternion Diff => Current * DefaultInv;

        public RotationDiff(IRotator rotator) {
            this.rotator = rotator;
            Default = rotator.Rotation;
            DefaultInv = Quaternion.Inverse(Default);
        }
    }
}
