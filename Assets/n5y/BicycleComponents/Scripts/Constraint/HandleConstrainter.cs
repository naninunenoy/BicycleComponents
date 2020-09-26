using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class HandleConstrainter : Constrainter {
        public HandleConstrainter(IConstraintee constraintee) : base(constraintee) { }

        public override void ApplyRotate(float angle, Vector3 axis) {
            var quaternion = Quaternion.AngleAxis(angle, axis);
            // 車輪のローカル座標が x-up/y-leftなので変換
            constraintee.Rotate(quaternion * Quaternion.AngleAxis(90F, Vector3.forward));
        }
    }
}
