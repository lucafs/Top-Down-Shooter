using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform alvo;
    float charPosX;
    float charPosY;
    void FixedUpdate()
    {
        
        charPosX = transform.position.x; 
        charPosY = transform.position.y;
        alvo.transform.position = new Vector3(charPosX, charPosY, -10);

    }

}
