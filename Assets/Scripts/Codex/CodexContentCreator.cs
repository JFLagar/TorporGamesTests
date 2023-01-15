using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexContentCreator : MonoBehaviour
{
    public Codex codex;
    public RectTransform topicParent;
    public CodexButton topicPrefab;
    public RectTransform entryParent;
    public CodexButton entryPrefab;
    public EntryDisplay entryDisplay;
    public CodexButton[] categoryButtons;
    private List<CodexButton> instantiatedTopics = new List<CodexButton>();
    private List<string> instantiatedTopicNames = new List<string>();
    private List<CodexButton> instantiatedEntries = new List<CodexButton>();
    public void CreateTopicButtons(CodexCategories category)
    {
        foreach(CodexButton codexButton in categoryButtons)
        {
            if(codexButton.category == category)
            {
                codexButton.buttonImage.sprite = codexButton.buttonSprites[1];
                codexButton.categoryButtonBackground.color = codexButton.buttonColors[1];
            }
            else
            {
                codexButton.buttonImage.sprite = codexButton.buttonSprites[0];
                codexButton.categoryButtonBackground.color = codexButton.buttonColors[0];
            }
        }
        if (instantiatedTopics.Count != 0)
        {
            foreach (CodexButton button in instantiatedTopics)
            {
                DestroyImmediate(button.gameObject);
            }
            instantiatedTopics.Clear();
            instantiatedTopicNames.Clear();
        }
        foreach (CodexEntry entry in codex.codexEntries.entries)
        {
            if (entry.category == category)
            {
              if (instantiatedTopicNames.Count == 0)
                {
                    CodexButton button = Instantiate(topicPrefab, topicParent);
                    button.parent = this;
                    button.buttonText.text = entry.codexTopic;
                    instantiatedTopicNames.Add(entry.codexTopic);
                    instantiatedTopics.Add(button);
                }
              else
                {
                    foreach(string topicName in instantiatedTopicNames)
                    {
                        if (entry.codexTopic == topicName)
                            return;
                        else
                        {
                            if(entry.codexTopic != "")
                            {
                                CodexButton button = Instantiate(topicPrefab, topicParent);
                                button.parent = this;
                                button.buttonText.text = entry.codexTopic;
                                instantiatedTopics.Add(button);
                                instantiatedTopicNames.Add(entry.codexTopic);
                                break;
                            }                                                  
                        }
                    }
                }
 
            }
        }
        instantiatedTopics[0].TopicButton();
    }
    public void CreateEntryButtons(string topicName)
    {
        foreach (CodexButton topic in instantiatedTopics)
        {
            if (topic.buttonText.text == topicName)
                topic.buttonImage.sprite = topic.buttonSprites[1];
            else
                topic.buttonImage.sprite = topic.buttonSprites[0];
        }
        if (instantiatedEntries.Count != 0)
        {
            foreach (CodexButton button in instantiatedEntries)
            {
                DestroyImmediate(button.gameObject);
            }
            instantiatedEntries.Clear();
        }
        foreach (CodexEntry entry in codex.codexEntries.entries)
        {
            if (entry.codexTopic == topicName)
            {
                    CodexButton button = Instantiate(entryPrefab, entryParent);
                    button.entry = entry;
                    button.parent = this;
                    button.buttonText.text = entry.name;
                    instantiatedEntries.Add(button);               
            }
        }
        instantiatedEntries[0].EntryButton();
    }
    public void ChangeEntryDisplay(CodexEntry entry)
    {
        foreach(CodexButton button in instantiatedEntries)
        {
            if (button.entry == entry)
                button.buttonText.font = Resources.Load<Font>("Art/Rubik-Bold");
            else
                button.buttonText.font = Resources.Load<Font>("Art/Rubik-Regular");

        }
        entryDisplay.text.text = entry.name;
        if (entry.imgName == "")
            entryDisplay.image.enabled = false;
        else
        {
            Sprite sprite = Resources.Load<Sprite>("Art/" + entry.imgName);
            entryDisplay.image.sprite = sprite;
            entryDisplay.image.enabled = true;
        }
        entryDisplay.description.text = entry.description;
    }
}
