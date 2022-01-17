using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myNS {
    public class TPCFollowTrackPosition : TPCFollow {
        public TPCFollowTrackPosition(Transform cT, Transform pT) : base(cT, pT) { }
        public override void Step() {
            Quaternion initialRotation = Quaternion.Euler(CamConsts.CameraAngleOffset);
            mCamTrans.rotation = Quaternion.RotateTowards(mCamTrans.rotation, initialRotation, Time.deltaTime * CamConsts.Damping);
            base.Step();
        }
    }
}
