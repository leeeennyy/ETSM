using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using System;

[Node(false, "Root")]
public class RootNode : Node {
    public override string GetID { get { return "RootNode"; } }
    public string Name = "";

    public override Node Create(Vector2 pos) {
        RootNode node = CreateInstance<RootNode>();
        node.rect = new Rect(pos.x, pos.y, 200, 100);
        node.name = "Root Node";

        node.CreateOutput("Next", "Default", NodeSide.Bottom);

        return node;
    }

    protected override void NodeGUI() {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Tree Name:");
        Name = GUILayout.TextField(Name);
        GUILayout.EndHorizontal();
    }
}
