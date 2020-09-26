using System;
using n5y.BicycleComponents.Constraint;
using UnityEngine;

namespace n5y.BicycleComponents {
    public class MonoBicycle : MonoBehaviour, IBicycle {
        [SerializeField] Transform handle = default;
        [SerializeField] Transform frontWheel = default;

        IConstrainter handleConstrainter;
        IConstraintee frontWheelConstraintee;

        void Awake() {
            frontWheelConstraintee = new TransformConstraintee(frontWheel);
            handleConstrainter = new HandleConstrainter(frontWheelConstraintee);
        }

        void Update() {
            handleConstrainter.ApplyRotate(handle.eulerAngles.y, handle.up);
        }
    }
}
