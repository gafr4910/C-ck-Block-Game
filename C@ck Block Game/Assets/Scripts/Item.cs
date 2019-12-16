using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public bool isInRange = false;
    public bool isPickedUp = false;
    public bool isDisguise = false;

    //Sound Stuff
    public AudioClip Pickup;
    private AudioSource source;

    private void Awake() //Sound Stuff
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        itemName = name;
    }

    void Update()
    {
        //Debug.Log(isInRange);
        if(isInRange && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("yep");
            isPickedUp = true;
            //Sound
            source.PlayOneShot(Pickup, 1f);
            Debug.Log("Picked Up Sound Play");
            
            //this.gameObject.SetActive(false);
            SpriteRenderer sprite = this.gameObject.GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            BoxCollider2D bCol = this.gameObject.GetComponent<BoxCollider2D>();
            if(bCol)
            {
                bCol.isTrigger = true;
            }
            CapsuleCollider2D cCol = this.gameObject.GetComponent<CapsuleCollider2D>();
            if(cCol)
            {
                cCol.isTrigger = true;
            }
            CircleCollider2D cirCol = this.gameObject.GetComponent<CircleCollider2D>();
            if(cirCol)
            {
                cirCol.isTrigger = true;
            }
        }
        //Debug.Log(isPickedUp);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        Debug.Log(other);
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
        Debug.Log(other);
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
