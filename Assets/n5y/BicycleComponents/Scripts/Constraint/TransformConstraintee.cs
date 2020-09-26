using System;
using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class TransformConstraintee : IConstraintee {
        public Action<Quaternion> OnRotated { get; }

        readonly Transform transform;
        public TransformConstraintee(Transform transform) => this.transform = transform;

        public void Rotate(Quaternion quaternion) {
            transform.rotation = quaternion;
            OnRotated?.Invoke(quaternion);
        }
    }
}
