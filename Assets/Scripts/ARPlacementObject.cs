using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

[RequireComponent(typeof(ARPlaneManager))]

public class ARPlacementObject : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private GameObject displayText;
    //private TextMeshPro text;

    private GameObject cube;

    private GameObject wall;

   

    [SerializeField]
    private ARPlaneManager aRPlaneManager;
    // Start is called before the first frame update
    void Start()
    {
        //displayText.SetActive(false);
        aRPlaneManager = GetComponent<ARPlaneManager>();
        aRPlaneManager.planesChanged += PlaneChanged;
      
       // cube = Instantiate(cubePrefab, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
    }

    void Awake()
    {

    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(args.added != null)
        {
            ARPlane aRPlane = args.added[0];
 
            cube = Instantiate(cubePrefab, aRPlane.transform.position, Quaternion.identity);
            wall = Instantiate(wallPrefab, aRPlane.transform.position, Quaternion.identity);
         
            Debug.Log("X:" + aRPlane.transform.position.x + "Y:" + aRPlane.transform.position.y + "Z:" + aRPlane.transform.position.z);
            aRPlaneManager.enabled = false;
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3);
    
        displayText.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
