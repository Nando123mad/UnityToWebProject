using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeButton : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;
    public GameObject castPoint;
    public float distanceToSee;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(castPoint.transform.position, castPoint.transform.forward);
        // Debug.DrawRay (castPoint.transform.position, castPoint.transform.forward * 50000000, Color.blue);
        // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Debug.DrawRay (ray.origin, ray.direction * 50000000, Color.red);

        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out hit, distanceToSee) && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Button Clicked!");
                unityEvent.Invoke();
            }
        }
    }
}
