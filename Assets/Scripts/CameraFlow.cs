using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    //===========================================
    //PUBLIC VARIABLES

    //what we want to follow
    public Transform target;

    //offset from target (so its not at the feet)
    public Vector3 offset;
    //===========================================

    // Update is called once per frame
    void Update()
    {
        //======================================================================
        //CAMERA FOLLOWING

        //makes it so the camera's position is the targets position + the offset
        transform.position = target.position + offset;
        //======================================================================
    }
}
