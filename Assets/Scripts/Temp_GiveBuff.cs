using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Temp_GiveBuff : MonoBehaviour
{
    public GameObject prefab;

    public int value = 0;
    public BuffType type;
    private void OnTriggerEnter(Collider other) {

        GameObject buff = Instantiate(prefab);
        Buff b= buff.GetComponent<Buff>();
        b.name = "Speed + 50%";
        b.bf_name = b.name;
        b.buffType = type;
        b.value = value;
        b.duration = 5;

        other.GetComponent<CharacterBuffs>().GetBuff(buff);

        Destroy(gameObject);
    }
}
