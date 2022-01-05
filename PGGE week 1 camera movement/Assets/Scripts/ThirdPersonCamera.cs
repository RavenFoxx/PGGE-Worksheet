using UnityEngine;
public class ThirdPersonCamera : MonoBehaviour
{
    public Transform mPlayer;
    TPCBase mThirdPersonCamera;
    public Vector3 mPositionOffset = new Vector3(0.0f, 2.0f, -2.5f);
    public Vector3 mAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
    public float mDamping = 1.0f;
    void Start()
    {
        //mThirdPersonCamera = new TPCTrack(transform, mPlayer);
        //mThirdPersonCamera = new TPCFollowTrackPosition(transform, mPlayer);
        mThirdPersonCamera = new TPCFollowTrackPositionAndRotation(transform, mPlayer);
        GameConstants.Damping = mDamping;
        GameConstants.CameraPositionOffset = mPositionOffset;
        GameConstants.CameraAngleOffset = mAngleOffset;
    }
    private void Update()
    {
        mThirdPersonCamera.Update();
    }
}
public abstract class TPCBase
{
    protected Transform mCameraTransform;
    protected Transform mPlayerTransform;
    public Transform CameraTransform { get { return mCameraTransform; } }
    public Transform PlayerTransform { get { return mPlayerTransform; } }
    public TPCBase(Transform cameraTransform, Transform playerTransform)
    {
        mCameraTransform = cameraTransform;
        mPlayerTransform = playerTransform;
    }
    public abstract void Update();
}
public class TPCTrack : TPCBase
{
    public TPCTrack(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
    {

    }
    public override void Update()
    {
        Vector3 targetPos = mPlayerTransform.position;
        targetPos.y += GameConstants.CameraPositionOffset.y;
        mCameraTransform.LookAt(targetPos);
    }
}
public abstract class TPCFollow : TPCBase
{
    public TPCFollow(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
    {

    }
    public override void Update()
    { 
        mCameraTransform.position = Vector3.Lerp(
            mCameraTransform.position,
            (mPlayerTransform.position - mCameraTransform.position),
            Time.deltaTime * GameConstants.Damping);
    }
}
public class TPCFollowTrackPosition : TPCFollow
{
    public TPCFollowTrackPosition(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
    {

    }
    public override void Update()
    {
        Quaternion initialRotation = Quaternion.Euler(GameConstants.CameraAngleOffset);
        mCameraTransform.rotation = Quaternion.RotateTowards(
            mCameraTransform.rotation,
            initialRotation,
            Time.deltaTime * GameConstants.Damping);
        base.Update();
    }
}
public class TPCFollowTrackPositionAndRotation : TPCFollow
{
    public TPCFollowTrackPositionAndRotation(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
    {

    }
    public override void Update()
    {
        Quaternion initialRotation = Quaternion.Euler(GameConstants.CameraAngleOffset);
        mCameraTransform.rotation = Quaternion.Lerp(
            mCameraTransform.rotation,
            mPlayerTransform.rotation * initialRotation,
            Time.deltaTime * GameConstants.Damping);
        base.Update();
    }
}
public static class GameConstants
{
    public static Vector3 CameraAngleOffset { get; set; }
    public static Vector3 CameraPositionOffset { get; set; }
    public static float Damping { get; set; }
}
