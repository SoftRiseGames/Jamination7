using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palto : MonoBehaviour,IInteract
{
    public GameObject Palto;

    public void interact()
    {
        EnterPalto();
    }
  
    void EnterPalto()
    {
       
        if (RandomEvents.isBadPalto)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            SystemSaveTool.instance.booleans.dataCheck.Add("isBadPalto");
        }
        else
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            SystemSaveTool.instance.booleans.dataCheck.Add("isGoodPalto");
        }
        SystemSaveTool.instance.JsonSaveVoid();
            
    }
}
