using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Transform Inventory;
    public GameObject equiped_Weapon; //사용중인 아이템
    public List<GameObject> lst_Invnetory = new List<GameObject>(); //인벤토리

    CharacterInteraction characterInteraction;
    CharacterEvent characterEvent;
    CharacterAnimationController characterAnimationController;

    private void Start() {
        characterInteraction = GetComponent<CharacterInteraction>();
        characterAnimationController = GetComponent<CharacterAnimationController>();
        characterEvent = GetComponent<CharacterEvent>();
    }

    private void Update() {
        //빠른 아이템 버리기
        if(Input.GetKeyDown(KeyCode.Q)) {
            if(lst_Invnetory.Count > 0) {
                DiscardItem(lst_Invnetory[0]);
            }
        }

        //빠른 무기 교체
        if(Input.GetKeyDown(KeyCode.R)) {
            GameObject target = null;
            try {
                target = lst_Invnetory.Where(x => x.GetComponent<Weapon>() != null).First();
            }
            catch {
                target = null;
            }
            if(target != null) {
                EquipItem(target);
                print("빠른 무기 교체");
            }
        }
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
            RemoveFromInventory(item);
            item.GetComponent<Item>().Discarded(transform);
        }
        item.transform.SetParent(null);
        characterEvent.act_DiscardItem?.Invoke();
    }
    public void EquipItem(GameObject item) {
        if(equiped_Weapon != null) {
            equiped_Weapon.GetComponent<Weapon>().Picked(gameObject);
        }
        equiped_Weapon = RemoveFromInventory(item);
        equiped_Weapon.transform.SetParent(characterAnimationController.handPos);
        equiped_Weapon.transform.position = characterAnimationController.handPos.position;
        equiped_Weapon.transform.rotation = characterAnimationController.handPos.rotation;
        equiped_Weapon.GetComponent<Weapon>().Visible(true);
    }

}
