using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myNS {
    public abstract class TPCFollow : TPCBase
    {
        public TPCFollow(Transform cT, Transform pT) : base(cT, pT) { }
        public override void Step() {
            Vector3 forward = mCamTrans.rotation * Vector3.forward;
            Vector3 right = mCamTrans.rotation * Vector3.right;
            Vector3 up = mCamTrans.rotation * Vector3.up;
            Vector3 targetPos = mPlayerTrans.position;
            Vector3 desiredPosition = targetPos
                + forward * CamConsts.CameraPositionOffset.z
                + right * CamConsts.CameraPositionOffset.x
                + up * CamConsts.CameraPositionOffset.y;
            Vector3 position = Vector3.Lerp(mCamTrans.position,
                desiredPosition, Time.deltaTime * CamConsts.Damping);
            mCamTrans.position = position;
        }
    }
}
