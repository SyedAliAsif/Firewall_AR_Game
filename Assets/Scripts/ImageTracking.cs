using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]


public class ImageTracking : MonoBehaviour
{
    //For scene management tracking reference image's name

    public static string sceneNamefromImage;

    [SerializeField]
    private GameObject[] placablePrefabs;

    private Dictionary<string, GameObject> spawnedprefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;


    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject prefab in placablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedprefabs.Add(prefab.name, newPrefab);
        }
    }

     private void OnEnable()
     {
         trackedImageManager.trackedImagesChanged += ImageChanged;
     }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedprefabs[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;

        //assigning the image name to the scene name variable for changing the scenes
        sceneNamefromImage = trackedImage.referenceImage.name;

        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnedprefabs[name];

        prefab.transform.position = position;
        prefab.SetActive(true);

        foreach (GameObject go in spawnedprefabs.Values)
        {
            if (go.name != name)
            {
                go.SetActive(false);
            }
        }
    }
}
