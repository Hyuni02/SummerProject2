using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Transform Inventory;
    public GameObject equiped_Weapon; //������� ������
    public List<GameObject> lst_Invnetory = new List<GameObject>(); //�κ��丮

    CharacterInteraction characterInteraction;
    CharacterEvent characterEvent;
    CharacterAnimationController characterAnimationController;

    private void Start() {
        characterInteraction = GetComponent<CharacterInteraction>();
        characterAnimationController = GetComponent<CharacterAnimationController>();
        characterEvent = GetComponent<CharacterEvent>();
    }

    private void Update() {
        //���� ������ ������
        if(Input.GetKeyDown(KeyCode.Q)) {
            if(lst_Invnetory.Count > 0) {
                DiscardItem(lst_Invnetory[0]);
            }
        }

        //���� ���� ��ü
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
                print("���� ���� ��ü");
            }
        }
    }

    public void AddToInventory(GameObject item) {
        lst_Invnetory.Add(item);
        Debug.LogWarning("�κ��丮 �� ������ �߰� �ҿ��� ����");
    }
    public GameObject RemoveFromInventory(GameObject item) {
        lst_Invnetory.Remove(item);
        Debug.LogWarning("�κ��丮 �� ������ ���� �ҿ��� ����");
        return item;
    }
    //���� ������, ���� �������� �������� ����������
    public void DiscardItem(GameObject item, bool fromHand = false) {
        //���������� ������ �̱���
        if(fromHand) {
            //���� ������ ������
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
