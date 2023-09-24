using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    [Header("체력")]
    public int maxHP;
    public int currentHP;
    [Header("이동")]
    public float speed;
    public float dashSpeed;
    public float jumpPower;
    [Header("상태")]
    public bool sprint;
    public bool isGrouned;
}
