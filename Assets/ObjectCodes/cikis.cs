using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cikis : MonoBehaviour,IInteract
{
    [SerializeField] GameObject getParent;
    public void interact()
    {
        Exit();
    }

    void Exit()
    {
        getParent.SetActive(false);
    }
}
