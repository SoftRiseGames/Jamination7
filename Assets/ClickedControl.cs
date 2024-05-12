using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class ClickedControl : MonoBehaviour
{
    public static Action isClicked;
    public float startpositionY;
    int inputGo;
    bool isHigh;
    private void Start()
    {
        startpositionY = transform.position.y;
    }
    void DistanceMeter()
    {
        if (Vector2.Distance(this.gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < 1.5f && !isHigh)
        {
            gameObject.transform.DOMoveY(gameObject.transform.position.y + .1f, .2f).OnStart(() => isHigh = true);
        }
        else if(Vector2.Distance(this.gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) >= 1.5f && isHigh)
        {
            gameObject.transform.DOMoveY(startpositionY, .2f).OnStart(() => isHigh = false);
        }
    }
    private void Update()
    {
        DistanceMeter();
    }

    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("inputGo", inputGo);
        isClicked?.Invoke();
    }

}
