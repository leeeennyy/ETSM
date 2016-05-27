using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{

    public float Speed = 0.2f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position -= new Vector3(Speed, 0.0f, 0.0f);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(Speed, 0.0f, 0.0f);
    }
}