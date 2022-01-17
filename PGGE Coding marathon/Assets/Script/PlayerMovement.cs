using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] CharacterController playerCC;
    [SerializeField] Animator playerAnim;
    float WalkSpeed = 1f;
    float RotSpeed = 50f;
    bool crouch = false;
    bool jump = false;
    bool autoFiring = false;
    bool burstFiring = false;
    bool singleFiring = false;
    [SerializeField] LayerMask groundMask;
    float groundCheckDist = 0.2f;
    float gravity = -9.81f;
    bool isGrounded;
    Vector3 mVelocity;
    float JumpForce = 1.5f;
    void Update() {
        HandleInputs();
        ApplyGravity();
        Move();
    }
    void HandleInputs() {
        if (autoFiring == false && burstFiring == false && singleFiring == false) autoFiring = true; //if no firing mode selected, default to auto.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            playerAnim.SetTrigger("Jump");
            mVelocity.y = Mathf.Sqrt(JumpForce * -2 * gravity);
        }
        if (Input.GetKeyDown(KeyCode.C)) crouch = !crouch; playerAnim.SetBool("Crouch", crouch);
        if (Input.GetKeyDown(KeyCode.B)) {// switch firing mode
            if (autoFiring == true) { // if on auto, switch to burst.
                autoFiring = !autoFiring;
                burstFiring = !burstFiring;
            }
            else if (burstFiring == true) { // if on burst, switch to single.
                burstFiring = !burstFiring;
                singleFiring = !singleFiring;
            }
            else { // if on single, switch to auto.
                singleFiring = !singleFiring;
                autoFiring = !autoFiring;
            }
        }
        if (Input.GetButtonDown("Fire1")) { // when shooting, start animation based on what firing type is used
            if (autoFiring) playerAnim.SetBool("Attack1", autoFiring);
            else if (burstFiring) playerAnim.SetBool("Attack2", burstFiring);
            else if (singleFiring) playerAnim.SetBool("Attack3", singleFiring);
        }
        if (Input.GetButtonUp("Fire1")) { //when not shooting, stop the animation used
            if (autoFiring) playerAnim.SetBool("Attack1", !autoFiring);
            else if (burstFiring) playerAnim.SetBool("Attack2", !burstFiring);
            else if (singleFiring) playerAnim.SetBool("Attack3", !singleFiring);
        }
        if (Input.GetKeyDown(KeyCode.R)) playerAnim.SetTrigger("Reload");
    }
    private void Move()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        float speed = WalkSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) { speed = WalkSpeed * 2.0f; }
        if (playerAnim == null) return;
        transform.Rotate(0.0f, hInput * RotSpeed * Time.deltaTime, 0.0f);
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
        forward.y = 0.0f;
        playerCC.Move(forward * vInput * speed * Time.deltaTime);
        playerAnim.SetFloat("PosX", 0);
        playerAnim.SetFloat("PosZ", vInput * speed / (2.0f * WalkSpeed));
    }
    void ApplyGravity() {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDist, groundMask);
        if (isGrounded && mVelocity.y < 0) {
            mVelocity.y = -2f;
        }
        mVelocity.y += gravity * Time.deltaTime;
        playerCC.Move(mVelocity * Time.deltaTime);
    }
}
