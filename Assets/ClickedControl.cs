using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ClickedControl : MonoBehaviour
{
    public static Action isClicked;
    private void OnMouseDown()
    {
        isClicked?.Invoke();
    }

}
