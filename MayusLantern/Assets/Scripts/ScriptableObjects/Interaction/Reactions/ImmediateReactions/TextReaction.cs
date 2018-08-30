using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextReaction : Reaction
{
    public bool isNPC;
    public string npcName;

    [TextArea]
    public string interactableText;

    [HideInInspector]
    public string[] textLines;

    DialogueManager textManager;

    protected override void SpecificInit()
    {
        textManager = FindObjectOfType<DialogueManager>();
        textLines = interactableText.Split("\\n"[0]);
    }
    protected override void ImmediateReaction()
    {
        if (isNPC)
        {
            textManager.npcDialogue = isNPC;
            textManager.npcNameText.text = npcName;
        }

        textManager.textLines = textLines;
        textManager.currentLine = 0;
        textManager.ShowTextBox();
    }
}
