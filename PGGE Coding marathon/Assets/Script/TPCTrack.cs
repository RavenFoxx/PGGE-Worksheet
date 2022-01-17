using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myNS {
    public class TPCTrack : TPCBase {
        public TPCTrack(Transform cT, Transform pT) : base(cT, pT) { }
        public override void Step() {
            Vector3 targetPos = mPlayerTrans.position;
            targetPos.y += CamConsts.CameraPositionOffset.y;
            mCamTrans.LookAt(targetPos);
        }
    }
}
