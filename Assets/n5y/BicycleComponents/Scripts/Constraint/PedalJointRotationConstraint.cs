using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class PedalJointRotationConstraint : IRotationConstraint {
        readonly IRotator pedal;
        readonly IRotator destination;
        readonly Quaternion defaultRotation;

        public PedalJointRotationConstraint(IRotator pedal, IRotator destination) {
            this.pedal = pedal;
            this.destination = destination;
            defaultRotation = destination.Rotation;
        }

        public void ApplyConstraint() {
            destination.Rotation = pedal.Rotation * defaultRotation;
        }
    }
}
