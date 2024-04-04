    using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private float startTime;
    private float updateDelayMin = 2f;
    private float updateDelayMax = 10f;
    private float closeDelay = 1f;
    public GameObject NameoftheGame;
    public GameObject Tamagochi;
    public GameObject UIDialogue;
    public float displayDurationofGameName = 5.0f;
    private float delayMedium = 5f;
    private int dialoguePhase = 0;

    void Start()
    {
        DialogueStart();
        startTime = Time.time;
    }

    void DialogueStart()
    {
        dialogueManager.ShowDialogue("Long ago, war raged in the world...");
        Tamagochi.gameObject.SetActive(true);
        Invoke("UpdateDialogue", delayMedium);
    }

    void UpdateDialogue()
    {
        if (dialoguePhase == 0)
        {
            dialogueManager.UpdateDialogue("All life came to an end... and from the ashes, new life emerged.");
            dialoguePhase++;
            Invoke("UpdateDialogue", delayMedium);
        }
        else if (dialoguePhase == 1)
        {
            dialogueManager.UpdateDialogue("Only life, artificial and real, who had the Will and Character to ascend could survive.");
            dialoguePhase++;
            Invoke("UpdateDialogue", delayMedium);
        }
        else if (dialoguePhase == 2)
        {
            dialogueManager.UpdateDialogue("Life... finds a way.");
            dialoguePhase++;
            Invoke("HideGameNameText", displayDurationofGameName);
        }
    }

    void HideGameNameText()
    {
        NameoftheGame.gameObject.SetActive(true);
        Invoke("CloseDialogue", closeDelay);
    }

    void CloseDialogue()
    {
        dialogueManager.HideDialogue();
        Tamagochi.SetActive(false);
        UIDialogue.SetActive(false);  
        NameoftheGame.gameObject.SetActive(false);
        float elapsedTime = Time.time - startTime;
        Debug.Log("Dialogue closed after " + elapsedTime + " seconds.");
    }
}