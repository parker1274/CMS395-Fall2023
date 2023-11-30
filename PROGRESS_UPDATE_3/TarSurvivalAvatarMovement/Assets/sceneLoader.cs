using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{

    public string nextSceneName; // Specify the name of the next scene in the Inspector
    public float delayBeforeLoading = 3f; // Set a delay before loading the next scene (optional)

    void Start()
    {
        // Invoke the LoadNextScene method after a specified delay
        Invoke("LoadNextScene", delayBeforeLoading);
    }

    void LoadNextScene()
    {
        // Load the next scene by name
        SceneManager.LoadScene(nextSceneName);
    }
}
