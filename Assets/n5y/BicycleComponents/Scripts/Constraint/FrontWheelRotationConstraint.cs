using System;
using UnityEngine;

namespace n5y.BicycleComponents.Constraint {
    public class FrontWheelRotationConstraint : IRotationConstraint {
        readonly RotationDiff parent;
        readonly RotationDiff handle;
        readonly RotationDiff rear;
        readonly IRotator destination;
        readonly Quaternion defaultRotation;

        public FrontWheelRotationConstraint(RotationDiff parent, IRotator handle, IRotator rear, IRotator destination) {
            this.parent = parent;
            this.handle = new RotationDiff(handle);
            this.rear = new RotationDiff(rear);
            this.destination = destination;
            defaultRotation = destination.Rotation;
        }

        public void ApplyConstraint() {
            var parentInv = Quaternion.Inverse(parent.Diff);
            destination.Rotation = handle.Diff * parentInv * rear.Diff * defaultRotation;
        }
    }
}
