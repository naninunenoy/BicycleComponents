using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public interface IConstrainter {
        void ApplyRotate(float angle, Vector3 axis);
    }
}
