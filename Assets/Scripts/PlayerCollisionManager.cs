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
		var go = collider.gameObject;

		if (go.tag == "Npc")
		{
			ChatDialog.SetActive(true);
		}
		else if (go.tag == "Door")
		{
			if (Input.GetKey(KeyCode.E))
			{
				if (go.name == "DoorToRoom")
				{
					MovePlayerToLastDoorPosition(1, collider.gameObject.transform.localPosition);
				}
				else if (go.name == "DoorToMain")
				{
					MovePlayerToLastDoorPosition(0, collider.gameObject.transform.localPosition);
				}
			}
		}

	}

	/// <summary>
	/// Moves the player to the last door position
	/// </summary>
	/// <param name="level">The new scene we want to load</param>
	/// <param name="doorPosition">The new door position</param>
	private void MovePlayerToLastDoorPosition(int level, Vector3 doorPosition)
	{
		if (GlobalStateManager.Instance.LastUsedDoorPosition == null)
		{
			GlobalStateManager.Instance.LastUsedDoorPosition = doorPosition;
			Application.LoadLevel(level);
			transform.localPosition = GlobalStateManager.Instance.LastUsedDoorPosition;
		}
		else
		{
			transform.localPosition = GlobalStateManager.Instance.LastUsedDoorPosition;
			Application.LoadLevel(level);
			GlobalStateManager.Instance.LastUsedDoorPosition = doorPosition;
		}
	}
}
