using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    [Header("ü��")]
    public int maxHP;
    public int currentHP;
    [Header("�̵�")]
    public float speed;
    public float dashSpeed;
    public float jumpPower;
    [Header("����")]
    public bool sprint;
    public bool isGrouned;
}
