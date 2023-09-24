using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandPos : MonoBehaviour
{
    private void Start() {
        transform.root.GetComponent<CharacterAnimationController>().handPos = transform;
    }
}
