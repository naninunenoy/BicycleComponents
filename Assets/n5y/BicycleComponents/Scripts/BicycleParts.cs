using n5y.BicycleComponents.Parts;
using n5y.BicycleComponents.Constraint;
using UnityEngine;

namespace n5y.BicycleComponents {
    public class BicycleParts : MonoBehaviour, IBicycle {
        [SerializeField] Transform handleLeft = default;
        [SerializeField] Transform handleRight = default;
        [SerializeField] Transform saddle = default;
        [SerializeField] Transform leftPedal = default;
        [SerializeField] Transform rightPedal = default;
        [SerializeField] BicycleFullConstraint fullConstraint = default;

        TransformParts handleLeftParts;
        public IParts HandleLeft => handleLeftParts;
        TransformParts handleRightParts;
        public IParts HandleRight => handleRightParts;
        TransformParts saddleParts;
        public IParts Saddle => saddleParts;
        TransformParts pedalLeftParts;
        public IParts PedalLeft => pedalLeftParts;
        TransformParts pedalRightParts;
        public IParts PedalRight => pedalRightParts;

        void Awake() {
            handleLeftParts = new TransformParts(handleLeft);
            handleRightParts = new TransformParts(handleRight);
            saddleParts = new TransformParts(saddle);
            pedalLeftParts = new TransformParts(leftPedal);
            pedalRightParts = new TransformParts(rightPedal);
        }

        public void PushPedal(float angle) {
            fullConstraint.PushPedal(angle);
        }

        public void SteerHandle(float angle) {
            fullConstraint.SteerHandle(angle);
        }
    }
}
