using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public GameObject interactableItem;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && interactableItem != null) {
            if (interactableItem.CompareTag("item")) {
                interactableItem.GetComponent<Item>().Picked(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("item")) {
            interactableItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("item")) {
            if(interactableItem == other.gameObject) {
                interactableItem = null;
            }
        }
    }
}
