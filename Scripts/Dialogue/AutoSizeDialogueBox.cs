using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AutoSizeDialogueBox : MonoBehaviour
{
    public Image backgroundImage;
    public TextMeshProUGUI textMeshProText;
    public RectTransform contentRectTransform;
    public float extraHeight = 50f; // Adjust this value based on your preference
    private string previousText;

    void Start()
    {
        // Initialize the previousText with the initial text
        previousText = textMeshProText.text;

        // Call the method to resize the dialogue box based on initial text content
        ResizeDialogueBox();
    }

    void Update()
    {
        // Check if the text has changed
        if (textMeshProText.text != previousText)
        {
            // Call the method to resize the dialogue box whenever the text changes
            ResizeDialogueBox();

            // Update the previousText to the current text
            previousText = textMeshProText.text;
        }
    }

    void ResizeDialogueBox()
    {
        // Force the ContentSizeFitter to recalculate the size
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRectTransform);

        // Get the preferred height of the text content
        float preferredHeight = textMeshProText.preferredHeight;

        // Add extra height to the preferred height
        float totalHeight = preferredHeight + extraHeight;

        // Set the size of the background image based on the total height
        RectTransform backgroundRectTransform = backgroundImage.rectTransform;
        backgroundRectTransform.sizeDelta = new Vector2(backgroundRectTransform.sizeDelta.x, totalHeight);
    }
}
