using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform alvo;

    void FixedUpdate()
    {
        
        float charPosX = transform.position.x; float charPosY = transform.position.y;
        alvo.transform.position = new Vector3(charPosX, charPosY, -10);

    }

}
