using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public List<GameObject> interactableItem = new List<GameObject>();

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && interactableItem != null) {
            if (interactableItem[0].CompareTag("item")) {
                interactableItem[0].GetComponent<Item>().Picked(gameObject);
                interactableItem.RemoveAt(0);
            }
        }
    }

}
