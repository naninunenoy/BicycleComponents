using n5y.BicycleComponents.Constraint;
using UnityEngine;

namespace n5y.BicycleComponents {
    public class BicycleConstraint : MonoBehaviour {
        [SerializeField] Transform handle = default;
        [SerializeField] Transform frontWheel = default;
        [SerializeField] Transform rearWheel = default;
        [SerializeField] Transform rightPedalCrankArmJoint = default;
        [SerializeField] Transform leftPedalCrankArmJoint = default;
        [SerializeField] Transform rightPedalJoint = default;
        [SerializeField] Transform leftPedalJoint = default;

        RotationDiff bicycle;
        IRotator bicycleRotator;
        IRotator handleRotator;
        IRotator frontWheelRotator;
        IRotator rearWheelRotator;
        IRotator rightPedalCrankArmJointRotator;
        IRotator leftPedalCrankArmJointRotator;
        IRotator rightPedalJointRotator;
        IRotator leftPedalJointRotator;

        IRotationConstraint pedalJointConstraint;
        IRotationConstraint frontWheelConstraint;
        IRotationConstraint rearWheelConstraint;
        IRotationConstraint pedalHorizontalConstraint;

        void Awake() {
            bicycleRotator = new TransformRotator(transform);
            bicycle = new RotationDiff(bicycleRotator);
            handleRotator = new TransformRotator(handle);
            frontWheelRotator = new TransformRotator(frontWheel);
            rearWheelRotator = new TransformRotator(rearWheel);
            rightPedalCrankArmJointRotator = new TransformRotator(rightPedalCrankArmJoint);
            leftPedalCrankArmJointRotator = new TransformRotator(leftPedalCrankArmJoint);
            rightPedalJointRotator = new TransformRotator(rightPedalJoint);
            leftPedalJointRotator = new TransformRotator(leftPedalJoint);

            pedalJointConstraint =
                new PedalJointRotationConstraint(rightPedalCrankArmJointRotator, leftPedalCrankArmJointRotator);
            rearWheelConstraint =
                new RearWheelRotationConstraint(rightPedalCrankArmJointRotator, rearWheelRotator);
            frontWheelConstraint =
                new FrontWheelRotationConstraint(bicycle, handleRotator, rearWheelRotator, frontWheelRotator);
            pedalHorizontalConstraint =
                new PedalHorizontalConstraint(bicycleRotator, leftPedalJointRotator, rightPedalJointRotator);
        }

        void Update() {
            pedalJointConstraint.ApplyConstraint();
            rearWheelConstraint.ApplyConstraint();
            frontWheelConstraint.ApplyConstraint();
            pedalHorizontalConstraint.ApplyConstraint();
        }

        public void PushPedal(float jointAngularVelocity) {
            rightPedalCrankArmJoint.Rotate(jointAngularVelocity, 0.0F, 0.0F);
        }

        public void SteerHandle(float angle) {
            var euler = handle.rotation.eulerAngles;
            euler.y = angle;
            handle.rotation = Quaternion.Euler(euler);
        }
    }
}
