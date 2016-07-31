using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject ChatDialog;
    public Player.States State = States.Explore;

    private float walkSpeed = 3f; //units/s ish

    Interactable interactTarget = null; //object to interact with when interact button pressed

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
                Dialogue();
                break;
        }
    }

    void Explore() {
        //handle movement input
        int movement = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        transform.position += new Vector3(movement * walkSpeed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Submit")) {
            //Action[] ThingsToDo = interactTarget.GetActionSet();
            //State = States.Decision;
            if (interactTarget != null) {
                Debug.Log("Interacted with " + interactTarget);
                State = States.Dialogue;
            }
            return;
        }
    }

    bool done = false;
    NodeEditorFramework.Node currentNode = null;
    void Dialogue() {
        if(currentNode == null) {
            //find conversation root node
            System.Collections.Generic.List<NodeEditorFramework.Node> nodes = interactTarget.InteractionTree.nodes;
            RootNode root = null;
            for(var i = 0; i < nodes.Count; ++i) {
                if(nodes[i] is RootNode) {
                    RootNode cur = (RootNode)nodes[i];
                    if (cur.Name == interactTarget.Root) {
                        root = cur;
                        break;
                    }
                }
            }
            if(root != null) {
                currentNode = root.Outputs[0].GetNodeAcrossConnection();
                done = false;
            }
            else {
                State = States.Explore;
                Debug.Log(string.Format("Could not find root node \"{0}\" in InteractionTree!"));
            }
        }
        else {//if there is a node to be done
            if (!done) {
                DialogueNode d = (DialogueNode) currentNode;
                Debug.Log(interactTarget.gameObject.name + " says: " + d.DialogueText);
                done = true;
            }
        }

        if (Input.GetButtonDown("Submit")) {
            if(currentNode != null) {
                //get the next node along
                currentNode = currentNode.Outputs[0].GetNodeAcrossConnection();
                done = false;
                if (currentNode == null) {
                    State = States.Explore;
                    Debug.Log("Conversation over!");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Interactable target = other.gameObject.GetComponent<Interactable>();
        if (target != null)
            interactTarget = target;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<Interactable>() == interactTarget)
            interactTarget = null;
    }
    
    void OnDrawGizmos() {
        if (interactTarget != null) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(interactTarget.transform.position, 0.2f);
        }
    }
    
}