using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform alvo;
    //public float smoothSpeed = 0.1f;
    //public Vector3 offSet;
    //public Vector3 rotation;
    // Update is called once per frame
    void FixedUpdate()
    {
        
        float charPosX = transform.position.x; float charPosY = transform.position.y;
        alvo.transform.position = new Vector3(charPosX, charPosY, -10);
        //    Vector3 desiredPosition = alvo.position + offSet;
        //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //    transform.position = smoothedPosition;
        //    transform.LookAt(alvo);
    }

}
