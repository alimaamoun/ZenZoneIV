using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
/// This script will take a string of a scene, and when some other event calls onIsland Select
/// The scene with that name will be asynchronously loaded.
/// </summary>
public class SceneSelector : MonoBehaviour
{
    [SerializeField] string sceneName;
    private float lastTapTime;
    private float doubleTapWindow = 0.3f;

    /// <summary>
    /// Event hook for activate trigger.
    /// </summary>
    /// <param name="args">Event info</param>
    public void onIslandSelect(ActivateEventArgs args)
    {
        float now = Time.time;
        if (now - lastTapTime < doubleTapWindow)
        {
            // Double tap detected       
            Debug.Log("Activated!!!");
            StartCoroutine(LoadIslandAsync());
        }
        else
        {
            // First tap
            lastTapTime = now;
        }

    }

    /// <summary>
    /// Creates a coroutine to load the scene while we can be able to have a loading screen.
    /// </summary>
    /// <returns>IEnumerator necessary for Coroutines</returns>
    IEnumerator LoadIslandAsync()
    {
        //keep track of async process
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        //Wait for asynchronous scene to fully load
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
