using System;
using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public interface IConstraintee {
        void Rotate(Quaternion quaternion);
        Action<Quaternion> OnRotated { get; }
    }
}
