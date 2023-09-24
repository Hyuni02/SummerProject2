using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("item")) {
            transform.parent.GetComponent<CharacterInteraction>().interactableItem.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("item")) {
            transform.parent.GetComponent<CharacterInteraction>().interactableItem.Remove(other.gameObject);
        }
    }
}
