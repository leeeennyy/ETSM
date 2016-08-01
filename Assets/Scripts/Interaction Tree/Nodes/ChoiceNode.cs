using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using System;
using UnityEditor;

[Node(false, "Choice Node")]
public class ChoiceNode : Node {
    public override string GetID { get { return "ChoiceNode"; } }
    public override bool AllowRecursion { get { return true; } }
    //public string Condition = ""; 
    public string Difficulty = ""; //function for difficulty e.g. pull - 5
    public string Choice = ""; //the text displayed for the choice

    public override Node Create(Vector2 pos) {
        ChoiceNode node = CreateInstance<ChoiceNode>();
        node.rect = new Rect(pos.x, pos.y, 200, 160);
        node.name = "Choice Node";

        node.CreateInput("Previous", "Default", NodeSide.Top);
        node.CreateOutput("Next", "Default", NodeSide.Bottom);

        return node;
    }

    protected override void NodeGUI() {
        GUILayout.BeginVertical();
        /*GUILayout.Label("Condition");
        Condition = GUILayout.TextField(Condition);*/
        GUILayout.Label("Difficulty Expression:");
        Difficulty = GUILayout.TextField(Difficulty);
        GUILayout.Label("Choice Text:");
        Choice = EditorGUILayout.TextArea(Choice, GUILayout.Width(200), GUILayout.Height(70));
        GUILayout.EndVertical();
    }
}
