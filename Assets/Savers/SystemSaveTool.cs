using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class boolManager
{
    public bool LibraryOpenBool;
    public bool isFavoriteFlower;
    public bool isgoodPalto;
    public bool isbadPalto;
    public bool isBadLibrary;
    public bool isGoodLibrary;
    public bool isShoe;
    public string BoyFavoriteAnimal;
    public string FavoriteFlower;
    public string shoeType;
}

public class SystemSaveTool : MonoBehaviour
{
    public static SystemSaveTool instance;
    public boolManager booleans;
    public TextAsset text;
    public string Jsondatas;

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
  
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
            Debug.Log("JSON dosyasý baþarýyla yüklendi.");
        }
        else
        {
            Debug.LogError("Belirtilen JSON dosyasý bulunamadý: " + filePath);
        }
    }
}
