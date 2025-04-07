//using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit;

//[RequireComponent(typeof(Rigidbody))]
//public class BallInteractable : XRGrabInteractable
//{
//    [Header("Recall Settings")]
//    [Range(1f, 30f)] public float recallSpeed = 10f;
//    [Range(0.05f, 1f)] public float snapDistance = 0.2f;

//    [Header("Throw Trajectory Settings")]
//    [Range(5f, 50f)] public float throwForce = 15f;
//    [Range(-1f, 1f)] public float verticalCurveOffset = 0.2f;

//    private Rigidbody rb;
//    private bool isRecalling = false;
//    private Transform currentHandTransform;
//    private IXRSelectInteractor currentInteractor;

//    protected override void Awake()
//    {
//        base.Awake();
//        rb = GetComponent<Rigidbody>();
//    }

//    protected override void OnHoverEntered(HoverEnterEventArgs args)
//    {
//        base.OnHoverEntered(args);
//        currentInteractor = args.interactorObject as IXRSelectInteractor;
//        currentHandTransform = args.interactorObject.transform;
//    }

//    protected override void OnHoverExited(HoverExitEventArgs args)
//    {
//        base.OnHoverExited(args);
//        currentInteractor = null;
//        currentHandTransform = null;
//    }

//    protected override void OnSelectEntered(SelectEnterEventArgs args)
//    {
//        base.OnSelectEntered(args);
//        isRecalling = false;
//        currentHandTransform = args.interactorObject.transform;
//    }

//    protected override void OnSelectExited(SelectExitEventArgs args)
//    {
//        base.OnSelectExited(args);
//        ApplyThrowTrajectory(args.interactorObject.transform);
//    }

//    private void Update()
//    {
//        HandleRecallInput();

//        if (isRecalling && currentHandTransform)
//        {
//            RecallTowardsHand();
//        }
//    }

//    private void HandleRecallInput()
//    {
//        if (currentInteractor is XRBaseControllerInteractor controller && controller.selectTarget == null)
//        {
//            if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool isGripping) && isGripping)
//            {
//                StartRecall();
//            }
//        }
//    }

//    private void StartRecall()
//    {
//        isRecalling = true;
//        rb.isKinematic = false;
//        rb.useGravity = false;
//    }

//    private void RecallTowardsHand()
//    {
//        Vector3 direction = (currentHandTransform.position - transform.position).normalized;
//        rb.velocity = direction * recallSpeed;

//        if (Vector3.Distance(transform.position, currentHandTransform.position) < snapDistance)
//        {
//            isRecalling = false;

//            if (interactionManager != null && currentInteractor != null)
//            {
//                var requestArgs = new SelectEnterEventArgs
//                {
//                    interactorObject = currentInteractor,
//                    interactableObject = this
//                };

//                interactionManager.RequestSelect(requestArgs);
//            }
//        }
//    }

//    private void ApplyThrowTrajectory(Transform throwOrigin)
//    {
//        rb.isKinematic = false;
//        rb.useGravity = true;

//        Vector3 direction = throwOrigin.forward + Vector3.up * verticalCurveOffset;
//        rb.velocity = direction.normalized * throwForce;
//    }
//}
