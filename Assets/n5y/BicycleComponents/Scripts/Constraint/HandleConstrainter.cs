﻿using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class HandleConstrainter : IConstrainter {
        readonly IConstraintee constraintee;
        public HandleConstrainter(IConstraintee constraintee) => this.constraintee = constraintee;

        public void ApplyRotate(float angle, Vector3 axis) {
            var quaternion = Quaternion.AngleAxis(angle, axis);
            // 車輪のローカル座標が x-up/y-leftなので変換
            constraintee.Rotate(quaternion * ConstrainterConstants.GlobalToWheel);
        }
    }
}
