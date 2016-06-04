using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    private static CanvasManager instance;

    public static CanvasManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CanvasManager>();
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }   
    }
}
