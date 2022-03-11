using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerRayCasting : MonoBehaviour
 {
     
    [SerializeField]
    [Tooltip("Set the distance from the object to the end point of the ray.")]
    public float distanceToSee;
    
    [SerializeField]
    [Tooltip("Text that is displayed when object is viewed.")]
    public GameObject uiObject;

    public string ObjectName;
    private Color highlightColor;
    Material originalMaterial, tempMaterial;
    Renderer rend = null;
    public Color StartColor;
    public Color EndColor;
    public float Speed;
    float startTime;


    void Start()
    {
        // highlightColor = Color.white;
        startTime = Time.time;
        uiObject.SetActive(false);
    }


    // Update is called once per frame
    void Update ()
    {
        RaycastHit hitInfo;
        Renderer currRend;
        
        //Draws ray in scene view during playmode; the multiplication in the second parameter controls how long the line will be
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        //A raycast returns a true or false value
        //we  initiate raycast through the Physics class
        //out parameter is saying take collider information of the object we hit, and push it out and 
        //store is in the what I hit variable. The variable is empty by default, but once the raycast hits
        //any collider, it's going to take the information, and store it in whatIHit variable. So then,
        //if I wanted to access something, I could access it through the whatIHit variable. 

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, distanceToSee))
        {

            currRend = hitInfo.collider.gameObject.GetComponent<Renderer>();
            float t = Mathf.Sin((Time.time - startTime) * Speed);

            if (currRend.gameObject.tag == "External_Page")//Checks to see if it's an extenal page object. else it keeps it's default material. 
            {
                
                if (currRend == rend)
                {
                    rend.material.color = Color.Lerp(StartColor, EndColor, t);  
                    return;
                }

                if (currRend && currRend != rend)
                {
                    if (rend)
                    {
                        rend.sharedMaterial = originalMaterial;
                    }

                }

                if (currRend)
                {
                    rend = currRend;
                }
                else
                {
                    Debug.Log("rend = currRend");
                    return;
                }

                originalMaterial = rend.sharedMaterial;

                tempMaterial = new Material(originalMaterial);
                rend.material = tempMaterial;
                rend.material.color = Color.Lerp(StartColor, EndColor, t);
                
                uiObject.SetActive(true);
            }
        }
        else
        {
            if (rend)
            {
                rend.sharedMaterial = originalMaterial;
                rend = null;
                uiObject.SetActive(false);
            }
        }                                                                          
    }
 }