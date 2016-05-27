using UnityEngine;
using System.Collections;
using System;

public class ChatDialog : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Npc")
        {
            // show chat dialog
        }
    }
}