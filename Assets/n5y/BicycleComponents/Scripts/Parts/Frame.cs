﻿using UnityEngine;

namespace n5y.BicycleComponents.Parts {
    public class Frame : IParts {
        public Vector3 Position { set; get; }
        public Quaternion Rotation { set; get; }
    }
}
