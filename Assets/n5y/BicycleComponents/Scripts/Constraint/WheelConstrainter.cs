using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class WheelConstrainter : IConstrainter {
        readonly IConstraintee constraintee;

        public WheelConstrainter(IConstraintee constraintee) => this.constraintee = constraintee;

        public virtual void ApplyRotate(float angle, Vector3 axis) {
            var quaternion = Quaternion.AngleAxis(angle, axis);
            // 車輪のローカル座標が x-up/y-leftなので変換
            constraintee.Rotate(quaternion * ConstrainterConstants.GlobalToWheel);
        }
    }
}
