using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController controller;
    CharacterState state;
    CharacterBuffs buffs;

    Vector3 velocity;
    Vector3 horiMove;
    float gravity = -9.8f * 3;

    private void Start() {
        buffs = GetComponent<CharacterBuffs>();
        controller = GetComponent<CharacterController>();
        state = GetComponent<CharacterState>();
    }

    private void Update() {
        //지면 감지
        state.isGrouned = controller.isGrounded;
        //이동 입력
        horiMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        horiMove *= state.sprint ? state.dashSpeed * buffs.con_speed : state.speed * buffs.con_speed;
        controller.Move(horiMove * Time.deltaTime);

        //대쉬 입력
        if (Input.GetKey(KeyCode.LeftShift)) state.sprint = true;
        else state.sprint = false;

        //점프 입력
        if (Input.GetKeyDown(KeyCode.Space) && state.isGrouned) {
            velocity.y = Mathf.Sqrt(state.jumpPower * buffs.con_jump * -3.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        if (state.isGrouned && velocity.y < -0.01f) velocity.y = -0.01f;
        controller.Move(velocity * Time.deltaTime);

    }

    private void FixedUpdate() {
        
    }

}
