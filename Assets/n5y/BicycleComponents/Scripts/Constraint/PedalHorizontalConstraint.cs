using System;
using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class PedalHorizontalConstraint : IRotationConstraint {
        readonly IRotator body;
        readonly IRotator leftPedal;
        readonly IRotator rightPedal;

        public PedalHorizontalConstraint(IRotator body, IRotator leftPedal, IRotator rightPedal) {
            this.body = body;
            this.leftPedal = leftPedal;
            this.rightPedal = rightPedal;
        }


        public void ApplyConstraint() {
            var euler = body.Rotation.eulerAngles;
            var rot = Quaternion.Euler(0.0F, euler.y, euler.z);
            leftPedal.Rotation = rot;
            rightPedal.Rotation = rot;
        }
    }
}
