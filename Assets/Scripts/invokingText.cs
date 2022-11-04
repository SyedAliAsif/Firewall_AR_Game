using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invokingText : MonoBehaviour
{
    public GameObject text;

    void Start()
    {
        text = GetComponent<GameObject>();
        text.SetActive(false);
        Invoke("EnableText", 5.0f);
    }

    private void EnableText()
    { 
            text.SetActive(true);
    }

}
