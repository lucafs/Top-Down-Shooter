using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Código pego no video: https://www.youtube.com/watch?v=joKG1QlYvsE

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private DoorHinge door;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && gm.coins >= 500)
        {
            gm.coins -= 500;
            door.OpenDoor();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            door.CloseDoor();
        }
    }
}
