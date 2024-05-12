using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : MonoBehaviour,IInteract
{
    public void interact()
    {
        shoetype();
    }
    void shoetype()
    {
        if (RandomEvents.shoes == 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            SystemSaveTool.instance.booleans.dataCheck.Add("isDog"); 
        }
            
        else if(RandomEvents.shoes == 1)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            SystemSaveTool.instance.booleans.dataCheck.Add("isCat");
        }
            
        SystemSaveTool.instance.booleans.shoeType = this.gameObject.name;
        SystemSaveTool.instance.JsonSaveVoid();
    }
}
