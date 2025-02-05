using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleTap(Input.mousePosition);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleTap(Input.GetTouch(0).position);
        }
    }

    private void HandleTap(Vector2 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(position), Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            
            if (hit.transform.TryGetComponent(out IInteractable interactable))
            {
                interactable.OnTap();
            }
        }
        else
        {
            Debug.Log("Ray did not hit any object.");
        }
    }
}