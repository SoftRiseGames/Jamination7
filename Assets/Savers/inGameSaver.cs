using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameSaver : MonoBehaviour
{
    public inGameSaver instance;

    public bool wifeImage;
    public bool FlowerLabel;


    void Start()
    {
        if (instance == null)
            instance = this;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (wifeImage && FlowerLabel)
        {
            SystemSaveTool.instance.booleans.WifeCard = true;
            SystemSaveTool.instance.JsonSaveVoid();
        }
    }
}
