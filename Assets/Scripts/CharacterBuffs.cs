using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuffs : MonoBehaviour
{
    [Header("결과값")]
    public float con_speed;
    public float con_dmg;
    public float con_jump;

    [Header("버프 리스트")]
    public List<GameObject> bf_speed = new List<GameObject>();
    public List<GameObject> bf_dmg = new List<GameObject>();
    public List<GameObject> bf_jump = new List<GameObject>();

    private void Update() {
        con_speed = Mathf.Max(Calc_confficient(bf_speed), 0);
        con_dmg = Mathf.Max(Calc_confficient(bf_dmg), 0);
        con_jump = Mathf.Max(Calc_confficient(bf_jump), 0);
    }

    public void RemoveBuff(GameObject buff) {
        switch (buff.GetComponent<Buff>().buffType) {
            case BuffType.speed:
                bf_speed.Remove(buff);
                break;
            case BuffType.dmg:
                bf_dmg.Remove(buff);
                break;
            case BuffType.jump:
                bf_jump.Remove(buff);
                break;
        }
    }

    public void GetBuff(GameObject buff) {
        switch (buff.GetComponent<Buff>().buffType) {
            case BuffType.speed:
                bf_speed.Add(buff);
                break;
            case BuffType.dmg:
                bf_dmg.Add(buff);
                break;
            case BuffType.jump:
                bf_jump.Add(buff);
                break;
        }
        buff.transform.parent = transform.Find("Buffs").transform;
    }

    float Calc_confficient(List<GameObject> list) {
        var total = 100;
        foreach (GameObject buff in list) {
            total += buff.GetComponent<Buff>().value;
        }
        return total * 0.01f;
    }
}
