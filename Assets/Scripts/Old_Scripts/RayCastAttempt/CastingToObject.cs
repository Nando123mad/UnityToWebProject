using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingToObject : MonoBehaviour
{
    public static string selectedObject;
    public string internalObject;
    public RaycastHit theObject;
    public GameObject castPoint;

    void Update()
    {
        Ray ray = new Ray(castPoint.transform.position, castPoint.transform.forward);
        // var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // ray.origin += new Vector3 (0f,0.5f,0f);
        Debug.DrawRay (castPoint.transform.position, castPoint.transform.forward * 50000000, Color.red);

        if(Physics.Raycast(ray, out theObject))
        {
            selectedObject = theObject.transform.gameObject.name;
            internalObject = theObject.transform.gameObject.name;
        }
    }
}
