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
        //���� ����
        state.isGrouned = controller.isGrounded;
        //�̵� �Է�
        horiMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        horiMove *= state.sprint ? state.dashSpeed * buffs.con_speed : state.speed * buffs.con_speed;
        controller.Move(horiMove * Time.deltaTime);

        //�뽬 �Է�
        if (Input.GetKey(KeyCode.LeftShift)) state.sprint = true;
        else state.sprint = false;

        //���� �Է�
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
