using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distancetrial : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector2.Distance(this.gameObject.transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition) ));
    }
}
