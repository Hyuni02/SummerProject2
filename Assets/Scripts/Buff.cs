using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType {
    speed, dmg, jump
}

public class Buff : MonoBehaviour
{
    public string bf_name;
    public float duration;
    float timer = 0;
    public BuffType buffType;
    public int value;

    void Update() {
        timer += Time.deltaTime;
        if(timer > duration) {
            transform.parent.parent.GetComponent<CharacterBuffs>().RemoveBuff(gameObject);
        }
    }
}
