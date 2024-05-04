using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Dialogue Set", menuName = "Dialogue Set/New Dialogue Set", order = 1)]
public class DialogueSet : ScriptableObject
{
    [System.Serializable]
    public class Dialogue
    {
        public string speakerName;
        [TextArea(3, 10)]
        public string dialogueText;
    }
    public Dialogue[] dialogues;

}
