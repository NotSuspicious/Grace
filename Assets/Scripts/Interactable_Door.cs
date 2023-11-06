using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable_Door : MonoBehaviour
{
    public GameObject openedDoor;
    public GameObject closedDoor;

    public void openDoor()
    {
        openedDoor.SetActive(true);
        closedDoor.SetActive(false);
    }

    public void closeDoor()
    {
        openedDoor.SetActive(false);
        closedDoor.SetActive(true);
    }

}
