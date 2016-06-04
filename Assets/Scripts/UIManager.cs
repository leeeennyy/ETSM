using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject chatDialog;

    // Use this for initialization
    void Start()
    {
        chatDialog.SetActive(false);
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    public void DisableUI()
    {
        chatDialog.SetActive(false);
    }
}
