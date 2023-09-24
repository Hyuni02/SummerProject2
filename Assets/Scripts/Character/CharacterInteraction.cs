using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{

    CharacterEvent characterEvent;

    //»πµÊ ∞°¥…«— æ∆¿Ã≈€ ∏Ò∑œ
    public List<GameObject> interactableItem = new List<GameObject>();


    private void Start() {
        characterEvent = GetComponent<CharacterEvent>();
    }

    private void Update() {
        //»π∆Ø ≈∞ ¿‘∑¬ Ω√ √π æ∆¿Ã≈€∏∏ »πµÊ
        if (Input.GetKeyDown(KeyCode.E) && interactableItem.Count > 0) {
            if (interactableItem[0].CompareTag("item")) {
                interactableItem[0].GetComponent<Item>().Picked(gameObject);
                interactableItem.RemoveAt(0);
                characterEvent.act_GetItem.Invoke();
            }
        }
    }

}
