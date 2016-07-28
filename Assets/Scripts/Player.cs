using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject ChatDialog;
    public Player.States State = States.Explore;

    private float walkSpeed = 3f; //units/s ish

    IInteractable interactTarget = null; //object to interact with when interact button pressed

    public enum States
    {
        Explore, //default state player walking place to place
        Decision, //player selecting a decision
        Dialogue //player doing dialogue (same as decision?)
    }

    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
        //decide what the player can do
        switch (State)
        {
            case States.Explore:
                Explore();
                break;
            case States.Decision:
                break;
            case States.Dialogue:
                break;
        }
    }

    void Explore() {
        //handle movement input
        int movement = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        transform.position += new Vector3(movement * walkSpeed * Time.deltaTime, 0, 0);

        if (Input.GetButton("Submit")) {
            //Action[] ThingsToDo = interactTarget.GetActionSet();
            //State = States.Decision;
            if(interactTarget != null)
                Debug.Log("Interacted with " + interactTarget);
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        IInteractable target = other.gameObject.GetComponent<IInteractable>();
        if (target != null)
            interactTarget = target;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<IInteractable>() == interactTarget)
            interactTarget = null;
    }
    
}