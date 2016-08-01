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


public class DefaultLink : IConnectionTypeDeclaration {
    public string Identifier { get { return "Default"; } }
    public Type Type { get { return typeof(void); } }
    public Color Color { get { return Color.red; } }
    public string InKnobTex { get { return "Textures/In_Knob.png"; } }
    public string OutKnobTex { get { return "Textures/Out_Knob.png"; } }
}
