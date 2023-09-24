using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Transform Inventory;
    public GameObject equiped_Weapon; //������� ������
    public List<GameObject> lst_Invnetory = new List<GameObject>(); //�κ��丮

    CharacterInteraction characterInteraction;

    private void Start() {
        characterInteraction = GetComponent<CharacterInteraction>();
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
            //�κ����� �ش� ������ ������
        }
    }
    public void EquipItem(GameObject item) {
        if(equiped_Weapon != null) {
            AddToInventory(equiped_Weapon);
        }
        equiped_Weapon = RemoveFromInventory(item);
    }

}
