using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour,IInteract
{
    public GameObject label;
    public void interact()
    {
        OpenLabel();
    }

    void OpenLabel()
    {
        Debug.Log("objectClick");
        label.gameObject.SetActive(true);
        SystemSaveTool.instance.booleans.FavoriteFlower = this.gameObject.name;
        SystemSaveTool.instance.JsonSaveVoid();

    }
}
