using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text interactableObjectText;
    public GameObject interactableObjectPanel;
    public GameObject npcNameTextBox;
    public Text npcNameText;

    [HideInInspector]
    public bool npcDialogue;
    //[HideInInspector]
    public string[] textLines;
    public int currentLine;
    PlayerController player;
    bool dialogueboxOpen;
    // Use this for initialization

    private void Awake()
    {
        
    }
    void Start()
    {
        //textLines = new string[1];
        interactableObjectPanel.SetActive(false);
        npcNameTextBox.SetActive(false);
        npcDialogue = false;
        dialogueboxOpen = false;
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }
        if (textLines == null)
        {
            return;
        }
        if (dialogueboxOpen)
        {
            if (currentLine >= textLines.Length)
            {
                interactableObjectPanel.SetActive(false);
                npcNameTextBox.SetActive(false);
                npcDialogue = false;
                player.enabled = true;
                currentLine = 0;
                dialogueboxOpen = false;
            }
            StartCoroutine("AnimateText");
        }
    }

    public void ShowTextBox()
    {
        dialogueboxOpen = true;
        player.enabled = false;
        player.GetComponent<Animator>().SetFloat("speed", 0f, player.speedDampTime, Time.deltaTime);
        if (npcDialogue)
        {
            npcNameTextBox.SetActive(true);
        }

        interactableObjectPanel.SetActive(true);
        StartCoroutine("AnimateText");
    }

    public void NextButton()
    {
        StopAllCoroutines();
        currentLine++;
    }


    IEnumerator AnimateText()
    {
        for (int i = 0; i < textLines[currentLine].Length; i++)
        {
            interactableObjectText.text = textLines[currentLine].Substring(0, i);
            yield return new WaitForSeconds(0.03f);
        }
    }
}
