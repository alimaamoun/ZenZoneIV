using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DragController : MonoBehaviour
{
    public CarouselManager carouselManager;
    private XRSimpleInteractable simpleInteractable;
    private Vector3 lastPosition;

    void Awake()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        Debug.Log("Card Awake");
        //simpleInteractable.selectEntered.AddListener(OnGrab);
        //simpleInteractable.selectExited.AddListener(OnRelease);
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("Hovering on card!");
    }


    public void OnEnterSelectCard(SelectEnterEventArgs args)
    {
        Debug.Log($"Card Selected By: {args.interactorObject.transform.name}");
        Debug.Log($"InteractorObject Location: {args.interactorObject.transform.position}");
        lastPosition = args.interactorObject.transform.position;
    }

    public void OnExitSelectCard(SelectExitEventArgs args)
    {
        Debug.Log($"Exit Selected Card: ");
        Vector3 currentPosition = args.interactorObject.transform.position;
        Vector3 delta = currentPosition - lastPosition;
        // Convert horizontal movement delta into an angular change (sensitivity factor applied)
        float deltaAngle = delta.x * 10f;
        // Estimate flick velocity (simplified)
        float angularVelocity = deltaAngle / Time.deltaTime;
        carouselManager.OnRelease(angularVelocity);
    }

    // Optionally, if you want to update during drag
    public void OnDragUpdate(UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor)
    {
        Vector3 currentPosition = interactor.transform.position;
        Vector3 delta = currentPosition - lastPosition;
        float deltaAngle = delta.x * 10f; // Sensitivity factor
        carouselManager.OnDrag(deltaAngle);
        lastPosition = currentPosition;
    }
}
