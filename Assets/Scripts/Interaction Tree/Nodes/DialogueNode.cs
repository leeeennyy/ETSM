using UnityEngine;
using System.Collections;
using System;
using NodeEditorFramework;
using UnityEditor;

[Node(false, "Dialogue")]
public class DialogueNode : Node {

    public override string GetID { get { return "DialogueNode"; } }

    public string DialogueText = "";

    public override Node Create(Vector2 pos) {
        DialogueNode node = CreateInstance<DialogueNode>();
        node.rect = new Rect(pos.x, pos.y, 200, 100);
        node.name = "Dialogue Node";

        node.CreateInput("Previous", "Default", NodeSide.Top);
        node.CreateOutput("Next", "Default", NodeSide.Bottom);

        return node;
    }

    protected override void NodeGUI() {
        GUILayout.BeginArea(new Rect(0, 0, rect.width, rect.height));
        DialogueText = EditorGUILayout.TextArea(DialogueText, GUILayout.Width(rect.width), GUILayout.Height(rect.height));
        GUILayout.EndArea();

    }
}
