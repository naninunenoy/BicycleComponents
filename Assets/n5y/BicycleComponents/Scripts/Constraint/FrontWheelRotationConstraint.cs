using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class FrontWheelRotationConstraint : IRotationConstraint {
        readonly IRotator handle;
        readonly IRotator rear;
        readonly IRotator destination;
        readonly Quaternion defaultRotation;
        readonly Quaternion defaultRotationInv;

        public FrontWheelRotationConstraint(IRotator handle, IRotator rear, IRotator destination) {
            this.handle = handle;
            this.rear = rear;
            this.destination = destination;
            defaultRotation = destination.Rotation;
            defaultRotationInv = Quaternion.Inverse(defaultRotation);
        }

        public void ApplyConstraint() {
            destination.Rotation =  handle.Rotation * (defaultRotationInv * (defaultRotation * rear.Rotation));
        }
    }
}
