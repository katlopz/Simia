using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;

    public Dialogue(string name, string sentence) {
        this.name = name;
        this.sentences = new string[1];
        this.sentences[0] = sentence;
    }

    public Dialogue(string name, string[] sentences)
    {
        this.name = name;
        this.sentences = sentences;
    }
}