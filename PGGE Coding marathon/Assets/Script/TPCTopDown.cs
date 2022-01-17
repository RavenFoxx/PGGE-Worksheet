using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myNS {
    public class TPCTopDown : TPCBase {
        public TPCTopDown(Transform cT, Transform pT) : base(cT, pT) { }
        public override void Step() {
            Vector3 targetPos = mPlayerTrans.position;
            targetPos.y += CamConsts.CameraPositionOffset.y + 5;
            Vector3 position = Vector3.Lerp(mCamTrans.position, targetPos, Time.deltaTime * CamConsts.Damping);
            mCamTrans.position = position;
            mCamTrans.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        }
    }
}