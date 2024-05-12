using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameSaver : MonoBehaviour
{
    public inGameSaver instance;

    public bool wifeImage;
    public bool FlowerLabel;
    
    public bool phoneOpen;
    public bool flowerOpen;
    public static bool LibraryOpenBool;


    void Start()
    {
        if (instance == null)
            instance = this;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(phoneOpen && flowerOpen)
        {
            SystemSaveTool.instance.booleans.dataCheck.Add("FavoriteFlower"); 
            SystemSaveTool.instance.JsonSaveVoid();
        }

    }
}
