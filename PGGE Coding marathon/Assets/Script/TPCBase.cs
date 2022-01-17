using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCBase {
    protected Transform mCamTrans;
    protected Transform mPlayerTrans;
    public Transform CamTrans { get { return mCamTrans; } }
    public Transform PlayerTrans { get { return mPlayerTrans; } }
    public TPCBase(Transform cT, Transform pT) {
        mCamTrans = cT;
        mPlayerTrans = pT;
    }
    public virtual void Step() { }
}
