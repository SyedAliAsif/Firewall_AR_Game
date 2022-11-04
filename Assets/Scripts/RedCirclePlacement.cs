using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

[RequireComponent(typeof(ARPlaneManager))]

public class RedCirclePlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject circlePrefab;

    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private GameObject displayText;
    //private TextMeshPro text;

    private GameObject circle;

    private GameObject wall;

    //variable for audio source
    public AudioSource audioSource;
    public AudioClip boomSound; 

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
        if (args.added != null)
        {

            //assign audio source to that audio clip
            audioSource.clip = boomSound;

            ARPlane aRPlane = args.added[0];

            circle = Instantiate(circlePrefab, aRPlane.transform.position, Quaternion.identity);
            wall = Instantiate(wallPrefab, aRPlane.transform.position, Quaternion.identity);

            Debug.Log("X:" + aRPlane.transform.position.x + "Y:" + aRPlane.transform.position.y + "Z:" + aRPlane.transform.position.z);
            aRPlaneManager.enabled = false;
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        //To play the boom sound 
        yield return new WaitForSecondsRealtime(1.5f);
        audioSource.Play();

        yield return new WaitForSecondsRealtime(2.5f);

        displayText.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
