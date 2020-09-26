using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class Constrainter : IConstrainter {
        protected readonly IConstraintee constraintee;

        public Constrainter(IConstraintee constraintee) => this.constraintee = constraintee;

        public virtual void ApplyRotate(float angle, Vector3 axis) {
            constraintee.Rotate(Quaternion.AngleAxis(angle, axis));
        }
    }
}
