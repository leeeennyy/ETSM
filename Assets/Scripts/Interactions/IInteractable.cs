using UnityEngine;
using System.Collections;


/// <summary>
/// Object that can be interacted with by the player
/// </summary>
public interface IInteractable {
    Action[] GetActionSet();
}
