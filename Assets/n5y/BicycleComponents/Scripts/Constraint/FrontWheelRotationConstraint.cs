using System;
using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class FrontWheelRotationConstraint : IRotationConstraint {
        readonly RotationDiff parent;
        readonly RotationDiff handle;
        readonly RotationDiff rear;
        readonly bool offHandleConstraint;
        readonly IRotator destination;
        readonly Quaternion defaultRotation;

        public FrontWheelRotationConstraint(RotationDiff parent, IRotator handle, IRotator rear, IRotator destination,
            bool offHandleConstraint = false) {
            this.parent = parent;
            this.handle = new RotationDiff(handle);
            this.rear = new RotationDiff(rear);
            this.destination = destination;
            this.offHandleConstraint = offHandleConstraint;
            defaultRotation = destination.Rotation;
        }

        public void ApplyConstraint() {
            var parentQuaternion = Quaternion.identity;
            if (!offHandleConstraint) {
                parentQuaternion =  handle.Diff * Quaternion.Inverse(parent.Diff);
            }
            var parentInv =
            destination.Rotation =  parentQuaternion * rear.Diff * defaultRotation;
        }
    }
}
