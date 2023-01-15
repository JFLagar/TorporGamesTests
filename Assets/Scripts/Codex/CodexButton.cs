using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodexButton : MonoBehaviour
{
    public Text buttonText;
    public CodexContentCreator parent;
    public CodexEntry entry;
    public CodexCategories category;
    public Image buttonImage, categoryButtonBackground;
    public Sprite[] buttonSprites;
    public Color32[] buttonColors;

    public void CategoryButton()
    {
        parent.CreateTopicButtons(category);
    }
    public void TopicButton()
    {
        parent.CreateEntryButtons(buttonText.text);
    }
    public void EntryButton()
    {
        parent.ChangeEntryDisplay(entry);
    }
}
