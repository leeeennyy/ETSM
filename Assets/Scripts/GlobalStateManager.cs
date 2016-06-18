using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalStateManager : MonoBehaviour
{
	private static GlobalStateManager instance;

	public static GlobalStateManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<GlobalStateManager>();
				DontDestroyOnLoad(instance.gameObject);
			}

			return instance;
		}
	}

	public int Counter = 0;
	public Text Label;
	public Vector3 LastUsedDoorPosition;

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

	// Use this for initialization
	void Start()
	{
		Label.text = Counter.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		Label.text = Counter.ToString();
	}
}
