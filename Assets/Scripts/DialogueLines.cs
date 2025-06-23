using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] private string[] dialogueLines;
    [SerializeField] TMP_Text dialogueText;
    private int currentLineIndex = 0;

    public void NextDialogueLine()
    {
        currentLineIndex++;
        dialogueText.text = dialogueLines[currentLineIndex];
    }
}
