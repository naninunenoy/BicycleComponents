using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class ConstraintApply {
        readonly IList<IRotator> rotators;
        public ConstraintApply(IList<IRotator> constraints) => this.rotators = constraints;

        public void Apply(Transform transform) {
            if (rotators == null || !rotators.Any()) {
                return;
            }

            transform.rotation = rotators
                .Aggregate(Quaternion.identity, (q, x) => q * x.Rotation);
        }
    }
}
