using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesButton : MonoBehaviour
{

    public Text buttonText;
    public NotesContentCreator parent;
    public JournalEntry entry;
    public JournalAct act;
    public Image buttonImage;
    public Sprite[] buttonSprites;
    public Color32[] buttonColors;
  
    public void AddTextButton()
    {
        parent.AddEntry();
    }
    public void ActButton()
    {
        parent.CreateJournalEntries(act);
    }
    public void RemoveEntryButton()
    {
        parent.RemoveEntry(entry);
    }
    public void NoteButton()
    {
        parent.NoteButton(this);
    }
    public void EnableRemoveButton()
    {
        buttonText.color = buttonColors[1];
        buttonImage.color = buttonColors[1];
    }
    public void DisableRemoveButton()
    {
        buttonText.color = buttonColors[0];
        buttonImage.color = buttonColors[0];
    }
}
