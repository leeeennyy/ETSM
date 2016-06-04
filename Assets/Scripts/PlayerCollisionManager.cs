using UnityEngine;
using System.Collections;

public class PlayerCollisionManager : MonoBehaviour
{
    public GameObject ChatDialog;

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
            ChatDialog.SetActive(true);
        }
        else if (collider.gameObject.name == "DoorToRoom")
        {
            // change the scene
            GlobalStateManager.Instance.LastUsedDoorPosition = collider.gameObject.transform.localPosition;
            Application.LoadLevel(1);
            transform.localPosition = GlobalStateManager.Instance.LastUsedDoorPosition;
        }
        else if (collider.gameObject.name == "DoorToMain")
        {
            GlobalStateManager.Instance.LastUsedDoorPosition = collider.gameObject.transform.localPosition;
            
            // change the scene
            Application.LoadLevel(0);
            transform.localPosition = GlobalStateManager.Instance.LastUsedDoorPosition;
        }
    }
}
