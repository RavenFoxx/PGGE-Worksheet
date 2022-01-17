using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myNS {
    public class TPCFollowTrackPositionAndRotation : TPCFollow
    {
        public TPCFollowTrackPositionAndRotation(Transform cT, Transform pT) : base(cT, pT) { }
        public override void Step() {
            Quaternion initialRotation = Quaternion.Euler(CamConsts.CameraAngleOffset);
            mCamTrans.rotation = Quaternion.Lerp( mCamTrans.rotation, mPlayerTrans.rotation * initialRotation, Time.deltaTime * CamConsts.Damping);
            base.Step();
        }
    }
}
