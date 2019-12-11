using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public bool isInRange = false;
    public bool isPickedUp = false;
    public bool isDisguise = false;
    
    void Start()
    {
        itemName = name;
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("yep");
            isPickedUp = true;
            //this.gameObject.SetActive(false);
            SpriteRenderer sprite = this.gameObject.GetComponent<SpriteRenderer>();
            sprite.enabled = false;
        }
        //Debug.Log(isPickedUp);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if(otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if(otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if(otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        if(otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

}
