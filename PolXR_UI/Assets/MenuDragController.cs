using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class MenuDragController : MonoBehaviour
{
    [SerializeField] private Transform _parentMenu;
    [SerializeField] private float _maxDistance = 0.5f;
   
    private XRGrabInteractable _grabInteractable;
    private Vector3 _originalLocalPos;
    private Transform _attachPoint;

    private void Awake()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _originalLocalPos = transform.localPosition;
       
        // Configure grab interactable properly
        _grabInteractable.trackScale = false;
        _grabInteractable.useDynamicAttach = false; // Critical for stable grabbing
       
        // Create a dedicated attach point
        _attachPoint = new GameObject("AttachPoint").transform;
        _attachPoint.SetParent(transform, false);
        _attachPoint.localPosition = Vector3.zero;
        _grabInteractable.attachTransform = _attachPoint;
       
        _grabInteractable.selectEntered.AddListener(OnGrabbed);
        _grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Position the attach point at the grab location
        _attachPoint.position = args.interactorObject.transform.position;
        _attachPoint.rotation = args.interactorObject.transform.rotation;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        // Snap back if too far
        if (Vector3.Distance(transform.position, _parentMenu.position) > _maxDistance)
            transform.localPosition = _originalLocalPos;
    }

    private void Update()
    {
        if (_grabInteractable.isSelected)
            ConstrainToParent();
    }

    private void ConstrainToParent()
    {
        float distance = Vector3.Distance(transform.position, _parentMenu.position);
        if (distance > _maxDistance)
        {
            Vector3 direction = (transform.position - _parentMenu.position).normalized;
            transform.position = _parentMenu.position + direction * _maxDistance;
        }
    }

    public void ResetPosition() => transform.localPosition = _originalLocalPos;

    private void OnDestroy()
    {
        if (_attachPoint != null)
            Destroy(_attachPoint.gameObject);
    }
}