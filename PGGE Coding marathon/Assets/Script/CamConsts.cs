using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myNS {
    public static class CamConsts {
        public static Vector3 CameraAngleOffset { get; set; }
        public static Vector3 CameraPositionOffset { get; set; }
        public static float Damping { get; set; }
        public static float RotationSpeed { get; set; }
        public static float MinPitch { get; set; }
        public static float MaxPitch { get; set; }
    }
}
