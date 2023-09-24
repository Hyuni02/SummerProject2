using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookDir {
    right, left
}

public class CharacterAnimationController : MonoBehaviour {
    Animator animator;

    public LookDir lookDir;

    private void Start() {
        SetAnimator();
    }

    public void SetAnimator() {
        animator = GetComponentInChildren<Animator>();
    }
}
