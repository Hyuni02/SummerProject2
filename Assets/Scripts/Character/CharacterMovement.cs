using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    CharacterState characterState;
    CharacterBuffs characterBuffs;
    CharacterEvent characterEvent;

    Vector3 velocity;
    [HideInInspector]
    public Vector3 horiMove;
    [HideInInspector]
    public bool jump;
    float gravity = -9.8f * 3;

    private void Start() {
        characterBuffs = GetComponent<CharacterBuffs>();
        characterController = GetComponent<CharacterController>();
        characterState = GetComponent<CharacterState>();
        characterEvent = GetComponent<CharacterEvent>();
    }

    private void Update() {
        //지면 감지
        characterState.isGrouned = characterController.isGrounded;
        //이동 입력
        horiMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        horiMove *= characterState.sprint ? characterState.dashSpeed * characterBuffs.con_speed : characterState.speed * characterBuffs.con_speed;
        characterController.Move(horiMove * Time.deltaTime);

        //대쉬 입력
        if (Input.GetKey(KeyCode.LeftShift)) characterState.sprint = true;
        else characterState.sprint = false;

        //점프 입력
        if (Input.GetKeyDown(KeyCode.Space) && characterState.isGrouned) {
            characterEvent.act_Jump?.Invoke();
            jump = true;
            velocity.y = Mathf.Sqrt(characterState.jumpPower * characterBuffs.con_jump * -3.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        if (characterState.isGrouned && velocity.y < -0.01f) {
            velocity.y = -0.01f;
            jump = false;
        }
        characterController.Move(velocity * Time.deltaTime);

    }
}
