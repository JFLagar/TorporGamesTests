using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesContentCreator : MonoBehaviour
{
    public Notes notes;
    public InputField inputField;
    public RectTransform entryParent;
    public NotesButton entryPrefab;
    public NotesButton[] actButtons;
    private List<NotesButton> instantiatedEntries = new List<NotesButton>();
    public JournalAct currentAct = JournalAct.ActI;

    public void CreateJournalEntries(JournalAct act)
    {
        currentAct = act;
        foreach (NotesButton actButton in actButtons)
        {
            if (actButton.act == act)
            {
                actButton.buttonImage.sprite = actButton.buttonSprites[1];
            }
            else
            {
                actButton.buttonImage.sprite = actButton.buttonSprites[0];
            }
        }

        if (instantiatedEntries.Count != 0)
        {
            foreach (NotesButton button in instantiatedEntries)
            {
                DestroyImmediate(button.gameObject);
            }
            instantiatedEntries.Clear();
        }
        foreach (JournalEntry entry in notes.journalEntries.entries)
        {
            if (entry.act == act && entry.text != "")
            {
                NotesButton button = Instantiate(entryPrefab, entryParent);
                button.entry = entry;
                button.parent = this;
                button.buttonText.text = entry.text;
                instantiatedEntries.Add(button);
            }
        }
    }
    public void AddEntry()
    {
        JournalEntry entry = new JournalEntry();
        entry.act = currentAct;
        entry.text = inputField.text;
        notes.journalEntries.entries.Add(entry);
        notes.SaveData();
    }
    public void NoteButton(NotesButton activeButton)
    { 
        foreach(NotesButton button in instantiatedEntries)
        {
            button.DisableRemoveButton();
        }
        activeButton.EnableRemoveButton();
    }
    public void RemoveEntry(JournalEntry entry)
    {
        foreach(JournalEntry j_entry in notes.journalEntries.entries)
        {
            if(j_entry.act == currentAct)
            {
                if(j_entry == entry)
                {
                    notes.journalEntries.entries.Remove(j_entry);
                    notes.SaveData();
                    return;
                }
            }
        }
 
    }
}
