using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    public GameObject ChatDialog;

    private float speed = 0.2f;
    //private int counter = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // If the dialog is not opened, enable movement
        if (!ChatDialog.activeSelf)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(speed, 0.0f, 0.0f);
                GlobalStateManager.Instance.Counter++;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(speed, 0.0f, 0.0f);
                GlobalStateManager.Instance.Counter++;
            }
        }
    }
}