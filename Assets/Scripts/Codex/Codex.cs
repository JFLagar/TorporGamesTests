using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum CodexCategories
{
    Characters,
    Locations,
    Organizations,
    History
}
public class Codex : MonoBehaviour
{
    public CodexContent codexEntries;
    public CodexContentCreator codexCreator;
    public TextAsset jsonFile;
    string saveFile;
    private bool dataLoaded = false;
    // Start is called before the first frame update
    void Awake()
    {
        saveFile = Application.persistentDataPath + "/codexEntries.JSON";

        if (!File.Exists(saveFile))
        {
            CreateData();
        }

    }
    private void OnEnable()
    {
        LoadData();
        codexCreator.CreateTopicButtons(CodexCategories.Characters);
    }
    void LoadData()
    {
        if (dataLoaded)
            return;
        string json = File.ReadAllText(saveFile);
        codexEntries = JsonUtility.FromJson<CodexContent>(json);
        dataLoaded = true;
    }
    void CreateData()
    {
        File.CreateText(saveFile).Close();
        File.WriteAllText(saveFile, jsonFile.text);
    }

}
[System.Serializable]
public class CodexContent
{
    public CodexEntry[] entries;
}

[System.Serializable]
public class CodexEntry
{
    public string name;
    public CodexCategories category;
    public string codexTopic;
    public string imgName;
    public string description;
}
