using UnityEngine;
using System.Collections;
using NodeEditorFramework;

[Node(false, "Condition Node")]
public class ConditionNode : Node {
    public override string GetID { get { return "ConditionNode"; } }
    public string Condition = ""; //expression to be evaluated to take Next, otherwise take Else

    public override Node Create(Vector2 pos) {
        ConditionNode node = CreateInstance<ConditionNode>();
        node.rect = new Rect(pos.x, pos.y, 200, 60);
        node.name = "Condition Node";

        node.CreateInput("Previous", "Default", NodeSide.Top);

        node.CreateOutput("Else", "Default", NodeSide.Right);

        node.CreateOutput("Next", "Default", NodeSide.Bottom);

        return node;
    }

    protected override void NodeGUI() {
        GUILayout.BeginHorizontal();
        Condition = GUILayout.TextField(Condition);
        GUILayout.EndHorizontal();
    }
}
