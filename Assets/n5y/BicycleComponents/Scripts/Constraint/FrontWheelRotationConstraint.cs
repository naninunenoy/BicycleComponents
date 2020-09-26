using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class FrontWheelRotationConstraint : IRotationConstraint {
        readonly IRotator handle;
        readonly IRotator rear;
        readonly Transform destination;

        public FrontWheelRotationConstraint(IRotator handle, IRotator rear, Transform destination) {
            this.handle = handle;
            this.rear = rear;
            this.destination = destination;
        }

        public void ApplyConstraint() {
            var handleAngle = -handle.Rotation.eulerAngles.y;
            var wheelAngle = rear.Rotation.eulerAngles.x;
            var handleRot = Quaternion.AngleAxis(handleAngle, destination.right);
            var wheelRot = Quaternion.AngleAxis(wheelAngle, destination.up);
            var euler = (handleRot * wheelRot* Constants.GlobalToWheel).eulerAngles;
            destination.rotation = Quaternion.Euler(euler);
        }
    }
}
