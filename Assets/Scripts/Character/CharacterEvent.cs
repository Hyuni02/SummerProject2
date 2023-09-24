using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvent : MonoBehaviour {
    public Action act_Move;
    public Action act_Jump;
    public Action act_Attack;
    public Action act_GetItem;
    public Action act_DiscardItem;
    public Action act_Die;
    public Action act_GetBuff;

    private void Start() {
        act_Move += debug_Move;
        act_Jump += debug_Jump;
        act_Attack += debug_Attack;
        act_GetItem += debug_GetItem;
        act_DiscardItem += debug_DiscardItem;
        act_Die += debug_Die;
        act_GetBuff += debug_GetBuff;
    }

    void debug_Move() {
        print("event : Move");
    }
    void debug_Jump() {
        print("event : Jump");
    }
    void debug_Attack() {
        print("event : Attack");
    }
    void debug_GetItem() {
        print("event : GetItem");
    }
    void debug_DiscardItem() {
        print("event : DiscardItem");
    }
    void debug_Die() {
        print("event : Die");
    }
    void debug_GetBuff() {
        print("event : GetBuff");
    }
}
