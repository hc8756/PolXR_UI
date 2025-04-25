using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

/*
// this code allows xr grabbable right on the parent
public class MenuController : MonoBehaviour
{
    public Transform user;              // The user's position (e.g. camera rig)
    public float offsetY = 0.8f;        // Waist height offset
    public float followRadius = 1.0f;   // Radius from user to follow
    public float maxDistance = 2.0f;    // Max distance user can drag the menu from themselves

    private bool isBeingDragged = false;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        //Debug.Log("Drag starts now");
        isBeingDragged = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isBeingDragged = false;
    }

    void Update()
    {
        if (!isBeingDragged)
        {
            Vector3 waistPosition = user.position + Vector3.up * offsetY;

            Vector3 cameraForward = user.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();

            transform.position = waistPosition + cameraForward * followRadius;
        }
        else
        {
            // Constrain menu within a max distance from the user
            Vector3 offset = transform.position - user.position;
            if (offset.magnitude > maxDistance)
            {
                offset = offset.normalized * maxDistance;
                transform.position = user.position + offset;
            }
        }

        // Always face the user horizontally
        Vector3 directionToCamera = user.position - transform.position;
        directionToCamera.y = 0;
        transform.rotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);
    }
}


*/



// original working code without grabbing functionality
public class MenuController : MonoBehaviour
{
     [SerializeField] public Transform user;
     public GameObject mainMenu;
     public GameObject radarMenu;
     public GameObject mapMenu;

     private Vector3 offset=new Vector3(0.0f,0.0f,0.0f);
    float radius= 0.15f;
    

    void Start()
    {
    }
    void Update()
    {

        Vector3 waistPosition= user.position + Vector3.up * offset.y;
        Vector3 cameraForward= user.forward;
        cameraForward.y=0;
        cameraForward.Normalize();

        transform.position=waistPosition + cameraForward*radius;
        Vector3 directionToCamera= user.position-transform.position;
        directionToCamera.y=0;
        transform.rotation=Quaternion.LookRotation(-directionToCamera, Vector3.up);
    }

    public void ToggleMain(){
        mainMenu.SetActive(!mainMenu.activeSelf);
    }

    public void ToggleRadar(){
        radarMenu.SetActive(!radarMenu.activeSelf);
    }
    public void ToggleMap(){
        mapMenu.SetActive(!mapMenu.activeSelf);
    }
}


/*
// doesn't work currently, needs debugging
public class MenuController : MonoBehaviour
{
    [Header("User Tracking")]
    [SerializeField] public Transform user;
    [SerializeField] private float _radius = 0.15f;
    private Vector3 _offset = new Vector3(0.0f, 0.0f, 0.0f);

    [Header("Submenus")]
    public GameObject mainMenu;
    public GameObject radarMenu;
    public GameObject mapMenu;
   
    void Update()
    {
        // Original follow behavior
        Vector3 waistPosition = user.position + Vector3.up * _offset.y;
        Vector3 cameraForward = user.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        transform.position = waistPosition + cameraForward * _radius;
        transform.rotation = Quaternion.LookRotation(-new Vector3(user.position.x, transform.position.y, user.position.z) + transform.position);
    }

    // Modified toggle methods to reset positions
    public void ToggleMain()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        if (mainMenu.activeSelf && mainMenu.TryGetComponent<MenuDragController>(out var draggable))
            draggable.ResetPosition();
    }

    public void ToggleRadar()
    {
        radarMenu.SetActive(!radarMenu.activeSelf);
        if (radarMenu.activeSelf && radarMenu.TryGetComponent<MenuDragController>(out var draggable))
            draggable.ResetPosition();
    }

    public void ToggleMap()
    {
        mapMenu.SetActive(!mapMenu.activeSelf);
        if (mapMenu.activeSelf && mapMenu.TryGetComponent<MenuDragController>(out var draggable))
            draggable.ResetPosition();
    }
}

*/