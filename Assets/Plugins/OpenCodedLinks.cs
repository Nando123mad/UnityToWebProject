using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class OpenCodedLinks : MonoBehaviour
{
    public static void OpenCodedLink()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
        Debug.Log("Button CLicked!");
        Debug.Log("Opening UrL to https://www.google.com/");
        OpenTab("https://www.google.com/");
        #endif
    }
    [DllImport("__Internal")]
    private static extern void OpenTab(string url);

}
