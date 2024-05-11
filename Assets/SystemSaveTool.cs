using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class boolManager
{
    public bool isPalto;
    public bool isPantolon;
}

public class SystemSaveTool : MonoBehaviour
{
    public SystemSaveTool instance;
    public boolManager booleans;
    public TextAsset text;
    public string Jsondatas;

    void Start()
    {
        if (instance == null)
            instance = this;
        LoadJson(); // Oyun ba�lad���nda JSON'u y�kle
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
            JsonSaveVoid();
    }

    public void JsonSaveVoid()
    {
        string jsonstring = JsonUtility.ToJson(booleans);

#if UNITY_EDITOR
        File.WriteAllText(Application.dataPath + "/JsonFolder/jsondata" + ".json", jsonstring);
#else
        if(!Directory.Exists(Application.persistentDataPath + "/JsonFolder"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/JsonFolder");
        }
        File.WriteAllText(Application.persistentDataPath + "/JsonFolder/jsondata.json", jsonstring);
        Debug.Log(Application.persistentDataPath + "/JsonFolder/jsondata.json");
#endif
    }

    public void LoadJson()
    {
#if UNITY_EDITOR
        string filePath = Application.dataPath + "/JsonFolder/jsondata.json";
#else
        string filePath = Application.persistentDataPath + "/JsonFolder/jsondata.json";
#endif

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            booleans = JsonUtility.FromJson<boolManager>(jsonString);
            Jsondatas = jsonString;
            Debug.Log("JSON dosyas� ba�ar�yla y�klendi.");
        }
        else
        {
            Debug.LogError("Belirtilen JSON dosyas� bulunamad�: " + filePath);
        }
    }
}
