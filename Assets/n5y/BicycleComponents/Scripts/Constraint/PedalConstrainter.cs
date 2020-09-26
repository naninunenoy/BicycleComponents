using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class PedalConstrainter : IConstrainter {
        readonly IConstraintee pedalConstraintee;
        readonly IConstraintee wheelConstraintee;

        public PedalConstrainter(IConstraintee oppositePedal, IConstraintee wheel) {
            pedalConstraintee = oppositePedal;
            wheelConstraintee = wheel;
        }

        public void ApplyRotate(float angle, Vector3 axis) {
            // へダルは対象に動かす
            pedalConstraintee.Rotate(Quaternion.AngleAxis(angle + 180.0F, axis));
            // 車輪のローカル座標が x-up/y-leftなので変換
            wheelConstraintee.Rotate(Quaternion.AngleAxis(angle, axis) * ConstrainterConstants.GlobalToWheel);
        }
    }
}
