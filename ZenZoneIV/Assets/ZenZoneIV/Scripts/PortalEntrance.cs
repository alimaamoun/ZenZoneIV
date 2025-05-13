using UnityEngine;

public class PortalEntrance : MonoBehaviour
{
    SceneLoader loader;
    [SerializeField] string sceneName;

    private void Start()
    {
        loader = FindFirstObjectByType<SceneLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        loader.LoadIsland(sceneName);
    }
}
