/*I'm thinking an action is anything the player can do with anything
 * Has an associated Condition for if it is displayed to the player
 *      - Probably need to calculate a value for how difficult this action is to take due to pull and other factors
 * Has Dialogue text field this will probably be more complicated
 *      - Dialogue system would process this text and fill in variables for things like different gender etc? maybe different dialogue trees/conditional actions will be needed for gender/orientation stuff? hmm
 *      - This should probably be different from an action? so 2 actions can have the same dialogue response and stuff like that but wahtever for now
 * this code is predicated on a scripting system we'd have to come up
 * Probably need more action types and stuff its pretty late can't really think lol
 */
public class Action {
    string Condition;
    string Effect; // I guess something like !Pull Add 0.5; !NPCRelationship Set 0; SceneTransition WorkAutumn
    Action[] Actions; //The follow up options/child dialogue nodes
    string Text; //Text displayed to the player describing the action
    string Dialogue; //The response to taking this action

    public Action(string Text, string Condition, string Effect, Action[] Actions, string Dialogue) {
        this.Text = Text;
        this.Condition = Condition;
        this.Effect = Effect;
        this.Actions = Actions;
        this.Dialogue = Dialogue;
    }
}