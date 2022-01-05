using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public CharacterController playerCC;
    public Animator playerAnim;
    public float mSpeed = 1.0f;
    public float rotSpeed = 50.0f;
    void Start() { playerCC = GetComponent<CharacterController>(); }
    void Update()
    {
        float horiInp = Input.GetAxis("Horizontal");
        float vertiInp = Input.GetAxis("Vertical");
        float speed = this.mSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) { speed = this.mSpeed * 2.0f; }
        if (playerAnim == null) return;

        transform.Rotate(0.0f, horiInp * rotSpeed * Time.deltaTime, 0.0f);
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
        forward.y = 0.0f;
        playerCC.Move(forward * vertiInp * speed * Time.deltaTime);

        playerAnim.SetFloat("PosX", 0);
        playerAnim.SetFloat("PosZ", vertiInp * speed / (2.0f * this.mSpeed));
    }
}
