using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public interface IConstrainter {
        void ApplyRotate(float angle, Vector3 axis);
    }

    public static class ConstrainterConstants {
        public static readonly Quaternion GlobalToWheel = Quaternion.AngleAxis(-90.0F, Vector3.forward);
    }
}
