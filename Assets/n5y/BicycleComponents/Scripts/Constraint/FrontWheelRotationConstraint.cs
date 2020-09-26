using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class FrontWheelRotationConstraint : IRotationConstraint {
        readonly IRotator handle;
        readonly IRotator rear;
        readonly IRotator destination;

        public FrontWheelRotationConstraint(IRotator handle, IRotator rear, IRotator destination) {
            this.handle = handle;
            this.rear = rear;
            this.destination = destination;
        }

        public void ApplyConstraint() {
            destination.Rotation = handle.Rotation * rear.Rotation;
        }
    }
}
