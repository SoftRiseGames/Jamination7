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
            SystemSaveTool.instance.booleans.shoeAnimType = "Dog";
        }
            
        else if(RandomEvents.shoes == 1)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            SystemSaveTool.instance.booleans.shoeAnimType = "Cat";
        }
        SystemSaveTool.instance.booleans.dataCheck.Add("isAnimal");
        SystemSaveTool.instance.JsonSaveVoid();
    }
}
