using UnityEngine;

namespace n5y.BicycleComponents.Parts {
    public class TransformParts : IParts {
        readonly Transform transform;
        public TransformParts(Transform transform) => this.transform = transform;

        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}
