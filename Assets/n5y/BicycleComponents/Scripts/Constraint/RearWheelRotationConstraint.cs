using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class RearWheelRotationConstraint : IRotationConstraint {
        readonly IRotator pedalJoint;
        readonly IRotator destination;
        readonly Quaternion defaultRotation;

        public RearWheelRotationConstraint(IRotator pedalJoint, IRotator destination) {
            this.pedalJoint = pedalJoint;
            this.destination = destination;
            defaultRotation = destination.Rotation;
        }

        public void ApplyConstraint() {
            destination.Rotation = pedalJoint.Rotation * defaultRotation;
        }
    }
}
