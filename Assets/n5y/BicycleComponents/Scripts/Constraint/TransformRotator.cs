using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class TransformRotator : IRotator {
        readonly Transform transform;
        public TransformRotator(Transform transform) => this.transform = transform;
        public Quaternion Rotation {
            get => transform == null ? Quaternion.identity : transform.rotation;
            set {
                if (transform != null) transform.rotation = value;
            }
        }
    }
}
