using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Transform Inventory;
    public GameObject equiped_Weapon; //사용중인 아이템
    public List<GameObject> lst_Invnetory = new List<GameObject>(); //인벤토리

    CharacterInteraction characterInteraction;

    private void Start() {
        characterInteraction = GetComponent<CharacterInteraction>();
    }

    public void AddToInventory(GameObject item) {
        lst_Invnetory.Add(item);
        Debug.LogWarning("인벤토리 내 아이템 추가 불완전 구현");
    }
    public GameObject RemoveFromInventory(GameObject item) {
        lst_Invnetory.Remove(item);
        Debug.LogWarning("인벤토리 내 아이템 제거 불완전 구현");
        return item;
    }
    //버릴 아이템, 버릴 아이템이 장착중인 아이템인지
    public void DiscardItem(GameObject item, bool fromHand = false) {
        //장착아이템 버리기 미구현
        if(fromHand) {
            //장착 아이템 버리기
        }
        else {
            //인벤에서 해당 아이템 버리기
        }
    }
    public void EquipItem(GameObject item) {
        if(equiped_Weapon != null) {
            AddToInventory(equiped_Weapon);
        }
        equiped_Weapon = RemoveFromInventory(item);
    }

}
