using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Código pego no video: https://www.youtube.com/watch?v=joKG1QlYvsE

public class DoorHinge : MonoBehaviour
{
    private HingeJoint2D hingeJoint2D;
    private JointAngleLimits2D openDoorLimits;
    private JointAngleLimits2D closeDoorLimits;

    private void Awake()
    {
        hingeJoint2D = transform.Find("Hinge").GetComponent<HingeJoint2D>();
        
        openDoorLimits = hingeJoint2D.limits;
        closeDoorLimits = new JointAngleLimits2D { min = 0f, max = 0f};
    }

    public void OpenDoor()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * 180);
        hingeJoint2D.limits = openDoorLimits;
    }

    public void CloseDoor()
    {
        hingeJoint2D.limits = closeDoorLimits;
    }
}
