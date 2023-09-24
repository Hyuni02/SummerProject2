using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public string description;
    public Sprite thumbnail;

    public virtual void Picked(GameObject player) {
        player.GetComponent<CharacterInventory>().AddToInventory(gameObject);
        Invisible();
        transform.parent = player.GetComponent<CharacterInventory>().Inventory;
    }

    public virtual void Discarded(Transform pos) {
        transform.position = pos.position;
        Visible();
    }

    public virtual void Invisible() {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
    }
    public virtual void Visible() {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
