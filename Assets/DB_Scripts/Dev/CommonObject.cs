using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonObject : MonoBehaviour
{
    [SerializeField] Outline outline;
    float y;

    public void Recover()
    {
        outline.enabled = false;
    }

    private void OnMouseDown()
    {
        MainController.Instance.SetHit(true, this);
        outline.enabled = true;

        y = gameObject.transform.position.y;
    }

    private void OnMouseDrag()
    {
        Plane plane = new Plane(Vector3.up, Vector3.up * y);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 p = ray.GetPoint(distance);
            transform.position = p;
        }
    }

    private void OnMouseUp()
    {
        MainController.Instance.SetHit(false);
    }
}
