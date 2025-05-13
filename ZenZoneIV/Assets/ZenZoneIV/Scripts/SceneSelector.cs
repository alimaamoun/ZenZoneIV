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

    [SerializeField] SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindFirstObjectByType<SceneLoader>();
    }

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
            sceneLoader.LoadIsland(sceneName);
        }
        else
        {
            // First tap
            lastTapTime = now;
        }

    }
}
