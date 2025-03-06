using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MenuController : MonoBehaviour
{
     [SerializeField] private Transform user;
     private Vector3 offset=new Vector3(0.0f,-0.4f,0.4f);
    

    void Start()
    {
    }
    void Update()
    {
        //Vector3 newPosition = user.position+offset;
        Vector3 newPosition = user.position;
        
        Vector3 direction= user.position- transform.position;
        direction.x=20;
        if(direction!=Vector3.zero){
            //transform.rotation=Quaternion.LookRotation(direction);
            transform.rotation = user.transform.rotation;

        }

        transform.position = newPosition;
    }
}
