using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class FrontWheelRotationConstraint : IRotationConstraint {
        readonly RotationDiff handle;
        readonly RotationDiff rear;
        readonly IRotator destination;
        readonly Quaternion defaultRotation;

        public FrontWheelRotationConstraint(IRotator handle, IRotator rear, IRotator destination) {
            this.handle = new RotationDiff(handle);
            this.rear = new RotationDiff(rear);
            this.destination = destination;
            defaultRotation = destination.Rotation;
        }

        public void ApplyConstraint() {
            destination.Rotation = handle.Diff * rear.Diff * defaultRotation;
        }
    }
}
