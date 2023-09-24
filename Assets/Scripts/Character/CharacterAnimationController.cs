using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookDir {
    right, left
}

public class CharacterAnimationController : MonoBehaviour {
    Animator animator;
    CharacterMovement characterMovement;

    public Transform handPos;

    private void Start() {
        SetAnimator();
        characterMovement = GetComponent<CharacterMovement>();
    }

    public void SetAnimator() {
        animator = GetComponentInChildren<Animator>();
    }
    void SetAnimation() {

    }
    private void Update() {
        if (Mathf.Abs(characterMovement.horiMove.x) > 0) {
            animator.SetBool("isRun", true);
            if(characterMovement.horiMove.x > 0) animator.transform.right = new Vector3(1,0,0); 
            else animator.transform.right = new Vector3(-1,0,0);
        }
        else {
            animator.SetBool("isRun", false);
        }

        if (characterMovement.jump) animator.SetBool("isJump", true);
        else animator.SetBool("isJump", false) ;


        SetAnimation();
    }
}
