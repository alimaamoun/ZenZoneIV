using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]public Animator sceneTransition;

    public void LoadIsland(string sceneName)
    {
        sceneTransition.SetTrigger("Start");

        StartCoroutine((LoadIslandAsync(sceneName)));

        sceneTransition.SetTrigger("Done");

    }

    /// <summary>
    /// Creates a coroutine to load the scene while we can be able to have a loading screen.
    /// </summary>
    /// <returns>IEnumerator necessary for Coroutines</returns>
    static IEnumerator LoadIslandAsync(string sceneName)
    {
        yield return new WaitForSeconds(1);
        //keep track of async process
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        //Wait for asynchronous scene to fully load
        while (!asyncLoad.isDone)
        {
            //loading or zoom in effect 
            yield return null;
        }
    }
}
