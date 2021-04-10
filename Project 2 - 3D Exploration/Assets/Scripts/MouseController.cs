﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float sensitivity = 10f;

    public Transform playerBody;

    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
 
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

        if(Input.GetKeyDown(KeyCode.L))
       {
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = true;
       }
        else if(Input.GetKey(KeyCode.Space))
       {
           Cursor.lockState = CursorLockMode.None;
       }
        
    }

}
