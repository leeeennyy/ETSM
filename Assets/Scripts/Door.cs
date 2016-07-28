using UnityEngine;
using System.Collections;
using System;

public class Door : MonoBehaviour, IInteractable {
    public String TargetScene;
    public Action[] Actions;
    bool locked = false;

    // Use this for initialization
    void Start () {
        Action a = new Action("Go to " + TargetScene, null, "SceneTransition TestScene2", null, null);
        Actions = new Action[] { a };
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Action[] GetActionSet() {
        return Actions;
    }


}
