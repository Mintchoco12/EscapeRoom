using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject textToDisplay;

    private bool playerInZone;
    private bool doorIsOpen;

    private void Start()
    {
        playerInZone = false;
        doorIsOpen = false;
        textToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && doorIsOpen == false && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("Button");
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0.5f);

        doorIsOpen = true;
        door.GetComponent<Animator>().Play("Door1");
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player is in zone
        if (other.gameObject.tag == "Player" && doorIsOpen == false)
        {
            //Show text
            textToDisplay.SetActive(true);
            playerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //If player exits zone
        if (other.gameObject.tag == "Player")
        {
            //Disable text
            playerInZone = false;
            textToDisplay.SetActive(false);
        }
    }

}

