using n5y.BicycleComponents.Constraint;
using UnityEngine;

namespace n5y.BicycleComponents {
    public class BicycleConstraint : MonoBehaviour, IBicycle {
        [SerializeField] Transform handle = default;
        [SerializeField] Transform frontWheel = default;
        [SerializeField] Transform rearWheel = default;
        [SerializeField] Transform rightPedalCrankArmJoint = default;
        [SerializeField] Transform leftPedalCrankArmJoint = default;

        IConstrainter handleConstrainter;
        IConstrainter rightPedalCrankArmJointConstrainter;
        IConstrainter rearPedalConstrainter;
        IConstraintee frontWheelConstraintee;
        IConstraintee rearWheelConstraintee;
        IConstraintee leftPedalCrankArmJointConstraintee;

        void Awake() {
            frontWheelConstraintee = new TransformConstraintee(frontWheel);
            rearWheelConstraintee = new TransformConstraintee(rearWheel);
            leftPedalCrankArmJointConstraintee = new TransformConstraintee(leftPedalCrankArmJoint);
            handleConstrainter = new HandleConstrainter(frontWheelConstraintee);
            rightPedalCrankArmJointConstrainter = new PedalConstrainter(leftPedalCrankArmJointConstraintee, rearWheelConstraintee);
            rearPedalConstrainter = new WheelConstrainter(frontWheelConstraintee);
        }

        void Update() {
            handleConstrainter.ApplyRotate(handle.eulerAngles.y, handle.up);
            rightPedalCrankArmJointConstrainter.ApplyRotate(
                rightPedalCrankArmJoint.eulerAngles.x, rightPedalCrankArmJoint.right);
            rearPedalConstrainter.ApplyRotate(rearWheel.eulerAngles.x, rearWheel.up);
        }
    }
}
