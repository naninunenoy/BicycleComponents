using UnityEngine;

namespace n5y.BicycleComponents.Parts {
    public interface IParts {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}
