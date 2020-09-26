using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class RearWheelRotationConstraint : IRotationConstraint {
        readonly IRotator pedalJoint;
        readonly Transform destination;

        public RearWheelRotationConstraint(IRotator pedalJoint, Transform destination) {
            this.pedalJoint = pedalJoint;
            this.destination = destination;
        }

        public void ApplyConstraint() {
            var euler = destination.rotation.eulerAngles;
            euler.x = -pedalJoint.Rotation.eulerAngles.x;
            destination.rotation = Quaternion.Euler(euler);
        }
    }
}
