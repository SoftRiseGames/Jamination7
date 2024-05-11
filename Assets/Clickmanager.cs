using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickmanager : MonoBehaviour
{
    public float raycastDistance = 100f;
    private void Start()
    {
        

    }
    private void Update()
    {
        Click();
    }
    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonunu al
            Vector3 mousePosition = Input.mousePosition;

            // Fare pozisyonunu kameranýn düzlemindeki bir noktaya çevir
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

            // Fare pozisyonundan belirtilen mesafede bir ýþýn çiz
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector3.forward, raycastDistance);

            // Eðer ýþýn bir þey vurduysa
            if (hit.collider != null)
            {
                if(hit.collider.TryGetComponent(out IInteract interactobject))
                {
                    interactobject.interact();
                }
            }
        }
        
    }
}
