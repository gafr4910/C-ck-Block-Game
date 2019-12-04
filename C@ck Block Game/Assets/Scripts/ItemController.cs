using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject[] FakeProposalScenario;
    public GameObject Jawsh;

    void Update()
    {
        foreach(GameObject i in Items)
        {
            if(i.name == "Waiter Bundle" && !i.activeSelf)
            {
                GameObject j = GameObject.Find("Jawsh");
                JawshMovement jMove = j.GetComponent<JawshMovement>();
                jMove.hasWaiterDisguise = true;
            }
        }
    }
}
