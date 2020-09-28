using UnityEngine;
using n5y.BicycleComponents.Parts;

namespace n5y.BicycleComponents {
    public interface IBicycle {
        void PushPedal(float angle);
        void SteerHandle(float angle);
        IParts Saddle { get; }
        IParts HandleLeft { get; }
        IParts HandleRight { get; }
        IParts PedalLeft { get; }
        IParts PedalRight { get; }
    }
}
