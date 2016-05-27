using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour
{
    public GameObject textbox;
    public Text text;

    public TextAsset textFile;
    public string[] lines;

    public int currentLine;
    public int endAtLine;

    public MovePlayer player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<MovePlayer>();

        if (textFile != null)
        {
            lines = textFile.text.Split('\n');
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
