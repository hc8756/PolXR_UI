using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MenuController : MonoBehaviour
{
     [SerializeField] public Transform user;
     private Vector3 offset=new Vector3(0.0f,-0.6f,0.4f);
    float radius= 0.2f;
    

    void Start()
    {
    }
    void Update()
    {
        /*
        Vector3 newPosition = user.position+offset;
        //newPosition.y = 1f;
        
        Vector3 direction= user.position- transform.position;
        direction.x=20;

        
        //transform.rotation=Quaternion.LookRotation(transform.position-user.position,user.up);
        //transform.rotation = user.transform.rotation;
        transform.rotation = Quaternion.Euler(0, user.transform.eulerAngles.y, 0);
        Debug.Log(transform.rotation);

        transform.position = newPosition;
        transform.position = user.position + user.rotation*offset;*/

        Vector3 waistPosition= user.position + Vector3.up * offset.y;
        Vector3 cameraForward= user.forward;
        cameraForward.y=0;
        cameraForward.Normalize();

        transform.position=waistPosition + cameraForward*radius;
        Vector3 directionToCamera= user.position-transform.position;
        directionToCamera.y=0;
        transform.rotation=Quaternion.LookRotation(-directionToCamera, Vector3.up);


    }
}
