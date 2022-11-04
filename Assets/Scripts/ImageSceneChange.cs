using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageSceneChange : MonoBehaviour
{
   // public ImageTracking sceneNameforButton;
    public void LoadScene()
    {
        string sceneName = ImageTracking.sceneNamefromImage;
        if (sceneName == "dhur")
        {
            SceneManager.LoadScene("TestAnim");

        }

        else if (sceneName == "Circle")
        {
            SceneManager.LoadScene("RedCircleScene");

        }
    }
}
