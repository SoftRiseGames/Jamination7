using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class library : MonoBehaviour,IInteract
{
    public void interact()
    {
        libraryControl();
    }

    void libraryControl()
    {
        if (!inGameSaver.LibraryOpenBool)
            transform.GetChild(0).gameObject.SetActive(true);
        else if(inGameSaver.LibraryOpenBool && RandomEvents.isBadPalto ==true && RandomEvents.scenarioWomanOrKid == 1)
            transform.GetChild(1).gameObject.SetActive(true);
        else if(inGameSaver.LibraryOpenBool && RandomEvents.isBadPalto == false && RandomEvents.scenarioWomanOrKid == 1)
            transform.GetChild(2).gameObject.SetActive(true);
        else if(inGameSaver.LibraryOpenBool && RandomEvents.isBadPalto == false && RandomEvents.scenarioWomanOrKid == 2)
            transform.GetChild(3).gameObject.SetActive(true);
        else if (inGameSaver.LibraryOpenBool && RandomEvents.isBadPalto == true && RandomEvents.scenarioWomanOrKid == 2)
            transform.GetChild(4).gameObject.SetActive(true);

        SystemSaveTool.instance.booleans.isShoe = true;
        SystemSaveTool.instance.JsonSaveVoid();

    }
}
