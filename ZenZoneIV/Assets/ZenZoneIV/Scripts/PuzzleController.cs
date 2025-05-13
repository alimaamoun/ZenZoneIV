using UnityEngine;
using UnityEngine.Events;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private int numberOfTasksComplete;
    [SerializeField] private ParticleSystem yay;
    [SerializeField] private ParticleSystem superyay;
    private int currentCompletedTasks = 0;



    public void CompletedPuxxleTask()
    {
        currentCompletedTasks++;
        yay.Play();
        CheckForPuxxleCompletition();
    }

    private void CheckForPuxxleCompletition()
    {
        if(currentCompletedTasks >= numberOfTasksComplete)
        {
            superyay.gameObject.SetActive(true);
            superyay.Play();
        }
    }
    
    public void puzzlePieceRemoved()
    {
        superyay.gameObject.SetActive(false);
        currentCompletedTasks--;
    }   
    
}
