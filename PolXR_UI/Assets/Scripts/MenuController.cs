using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
     [SerializeField] public Transform user;
     public GameObject mainMenu;
     public GameObject radarMenu;

     private Vector3 offset=new Vector3(0.0f,-0.7f,0.4f);
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


}
