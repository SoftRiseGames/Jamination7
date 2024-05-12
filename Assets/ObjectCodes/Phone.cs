using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteract
{
    
    public void interact()
    {
        image();
    }
    void image()
    {
        if (RandomEvents.scenarioWomanOrKid == 1)
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        else
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        inGameSaver.LibraryOpenBool = true;
        
    }
    
}
