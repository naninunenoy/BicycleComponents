using n5y.BicycleComponents.Constraint;
using UnityEngine;

namespace n5y.BicycleComponents {
    public class BicycleConstraint : MonoBehaviour, IBicycle {
        [SerializeField] Transform handle = default;
        [SerializeField] Transform frontWheel = default;
        [SerializeField] Transform rearWheel = default;
        [SerializeField] Transform rightPedalCrankArmJoint = default;
        [SerializeField] Transform leftPedalCrankArmJoint = default;

        IRotator handleRotator;
        IRotator frontWheelRotator;
        IRotator rearWheelRotator;
        IRotator rightPedalCrankArmJointRotator;
        IRotator leftPedalCrankArmJointRotator;

        IRotationConstraint pedalJointConstraint;
        IRotationConstraint frontWheelConstraint;
        IRotationConstraint rearWheelConstraint;

        void Awake() {
            handleRotator = new TransformRotator(handle);
            frontWheelRotator = new TransformRotator(frontWheel);
            rearWheelRotator = new TransformRotator(rearWheel);
            rightPedalCrankArmJointRotator = new TransformRotator(rightPedalCrankArmJoint);
            leftPedalCrankArmJointRotator = new TransformRotator(leftPedalCrankArmJoint);

            pedalJointConstraint =
                new PedalJointRotationConstraint(rightPedalCrankArmJointRotator, leftPedalCrankArmJointRotator);
            rearWheelConstraint = new RearWheelRotationConstraint(rightPedalCrankArmJointRotator, rearWheelRotator);
            frontWheelConstraint = new FrontWheelRotationConstraint(handleRotator, rearWheelRotator, frontWheelRotator);
        }

        void Update() {
            pedalJointConstraint.ApplyConstraint();
            rearWheelConstraint.ApplyConstraint();
            frontWheelConstraint.ApplyConstraint();

            handle.Rotate(new Vector3(0, 0.5F, 0));
            rightPedalCrankArmJoint.Rotate(new Vector3(1, 0, 0));
        }
    }
}
