using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myNS;
public enum CameraType { TRACK, FOLLOW_POS, FOLLOW_POS_ROT, TOP_DOWN }
public class TPC : MonoBehaviour {
    [SerializeField] CameraType mCameraType = CameraType.TRACK;
    [SerializeField] Transform mPlayer;
    Vector3 mAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 mPositionOffset = new Vector3(0.0f, 1.6f, -2.5f);
    Dictionary<CameraType, TPCBase> myCameras = new Dictionary<CameraType, TPCBase>();
    float mDamping = 1.0f;
    private void Start() {
        myCameras.Add(CameraType.TRACK, new TPCTrack(transform, mPlayer));
        myCameras.Add(CameraType.FOLLOW_POS, new TPCFollowTrackPosition(transform, mPlayer));
        myCameras.Add(CameraType.FOLLOW_POS_ROT, new TPCFollowTrackPositionAndRotation(transform, mPlayer));
        myCameras.Add(CameraType.TOP_DOWN, new TPCTopDown(transform, mPlayer));
        CamConsts.Damping = mDamping;
        CamConsts.CameraPositionOffset = mPositionOffset;
        CamConsts.CameraAngleOffset = mAngleOffset;
    }
    private void LateUpdate() {
        myCameras[mCameraType].Step();
    }
    //test
}
