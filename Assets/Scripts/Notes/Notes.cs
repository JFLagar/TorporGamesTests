using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public enum JournalAct
{
    ActI,
    ActII,
    ActIII,
    ActIV
}
public class Notes : MonoBehaviour
{
    public JournalContent journalEntries;
    public NotesContentCreator contentCreator;
    public TextAsset jsonFile;
    private string saveFile;
    // Start is called before the first frame update
    void Awake()
    {
        saveFile = Application.persistentDataPath + "/journalEntries.JSON";

        if (!File.Exists(saveFile))
           CreateData();
    }

    private void OnEnable()
    {
        LoadData();
    }
    private void CreateData()
    {
        File.CreateText(saveFile).Close();
        File.WriteAllText(saveFile, jsonFile.text);
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(journalEntries);
        File.WriteAllText(saveFile, json);
        LoadData();
    }
    private void LoadData()
    {
        string json = File.ReadAllText(saveFile);
        journalEntries = JsonUtility.FromJson<JournalContent>(json);
        contentCreator.CreateJournalEntries(contentCreator.currentAct);
    }

}
[System.Serializable]
public class JournalContent
{
    public List<JournalEntry> entries = new List<JournalEntry>();
}

[System.Serializable]
public class JournalEntry
{
    public string text;
    public JournalAct act;
}
