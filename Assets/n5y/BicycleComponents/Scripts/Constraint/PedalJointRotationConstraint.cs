using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class PedalJointRotationConstraint : IRotationConstraint {
        readonly IRotator pedal;
        readonly Transform destination;

        public PedalJointRotationConstraint(IRotator pedal, Transform destination) {
            this.pedal = pedal;
            this.destination = destination;
        }

        public void ApplyConstraint() {
            var roundAngle = pedal.Rotation.eulerAngles.x;
            var quaternion = Quaternion.AngleAxis(roundAngle + 180.0F, destination.right);
            destination.rotation = quaternion;
        }
    }
}
