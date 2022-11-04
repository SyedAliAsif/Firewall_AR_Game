using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBlockedController : MonoBehaviour
{
    public static string blockedStatusValue;
    public void setValue(string text)
    {
        blockedStatusValue = transform.Find("Text").GetComponent<string>();
    }
}
