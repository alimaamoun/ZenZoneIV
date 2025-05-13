using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DebugInteractableCube : MonoBehaviour
{

    private XRSimpleInteractable simpleInteractable;

    private void Awake()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("Hovering on card!");
    }


    public void OnEnterSelectCard(SelectEnterEventArgs args)
    {
        Debug.Log($"Card Selected By: {args.interactorObject.transform.name}");
        Debug.Log($"InteractorObject Location: {args.interactorObject.transform.position}");
    }

    public void OnExitSelectCard(SelectExitEventArgs args)
    {
        Debug.Log($"Exit Selected Card: ");
    }

}
