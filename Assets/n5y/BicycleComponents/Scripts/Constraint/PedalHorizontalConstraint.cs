using UnityEditorInternal;
using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class PedalHorizontalConstraint : IRotationConstraint {
        readonly IRotator left;
        readonly IRotator right;
        readonly Vector3 gravityDirection;

        public PedalHorizontalConstraint(IRotator left, IRotator right, Vector3 gravityDirection) {
            this.left = left;
            this.right = right;
            this.gravityDirection = gravityDirection;
        }

        public void ApplyConstraint() {
            var yaw = right.Rotation.eulerAngles.y;
            right.Rotation = Quaternion.AngleAxis(yaw, gravityDirection);
            yaw = left.Rotation.eulerAngles.y;
            left.Rotation = Quaternion.AngleAxis(yaw, gravityDirection);
        }
    }
}
