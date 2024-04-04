using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMesh Pro namespace

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI  dialogueText; // Use TextMeshProUGUI for text

    public Image textboxImage;
    public bool isActive = false;

    public void ShowDialogue(string text)
    {
        dialogueText.text = text;
        isActive = true;
        textboxImage.enabled = true;
        dialogueText.enabled = true;
    }

    public void HideDialogue()
    {
        isActive = false;
        textboxImage.enabled = false;
        dialogueText.enabled = false;
    }

    public void UpdateDialogue(string newText)
    {
        if (isActive)
        {
            dialogueText.text = newText;
        }
    }
}