using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour
{
    public Image textbox;
    public Text text;
    public string itemName;
    public bool isInRange = false;
    public bool isPickedUp = false;

    void Start()
    {
        textbox.enabled = false;
        text.enabled = false;
        itemName = name;
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("yep");
            textbox.enabled = true;
            text.enabled = true;
            Invoke("ClearText", 2);
        }
        //Debug.Log(isPickedUp);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if (otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if (otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        //Debug.Log(other);
        if (otherGO.name == "Jawsh")
        {
            isInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        if (otherGO.name == "Jawsh")
        {
            isInRange = false;
        }
    }

    private void ClearText()
    {
        textbox.enabled = false;
        text.enabled = false;
    }

}
