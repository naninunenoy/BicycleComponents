using System.Collections.Generic;
using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public interface IRotationConstraint {
        void ApplyConstraint();
    }

    public static class Constants {
        public static readonly Quaternion GlobalToWheel = Quaternion.AngleAxis(-90.0F, Vector3.forward);
    }
}
