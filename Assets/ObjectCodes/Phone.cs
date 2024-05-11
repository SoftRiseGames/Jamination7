using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteract
{
    public GameObject wifeImage;
    public void interact()
    {
        image();
    }
    void image()
    {
        wifeImage.gameObject.SetActive(true);
    }
    
}
