using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{       
    [SerializeField] private Manager manager;
    [SerializeField] private GameObject interactable;
    [SerializeField] private GameObject textToDisplay;

    private bool playerInZone;
    
    private void Start()
    {
        playerInZone = false;
        textToDisplay.SetActive(false);
    }

    private void Update()
    {
        //Open door
        if (playerInZone && manager.stage[2] && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("Button");
            StartCoroutine(OpenDoor());
        }

        //Open lock
        if (playerInZone && Input.GetMouseButtonDown(0))
        {
            manager.UnlockLock();
            print("test");
        }

        ////Open lock
        //if (playerInZone && manager.keyInHand && Input.GetMouseButtonDown(0))
        //{
        //    manager.UnlockLock();
        //    print("test");
        //}

        //Open first chest
        if (playerInZone && manager.stage[1] && Input.GetKeyDown(KeyCode.E))
        {
            interactable.GetComponent<Animator>().Play("Chest");
            StartCoroutine(manager.OpenChest());
        }

        //Bookshelf lever
        if (playerInZone && manager.stage[2] && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("lever");  
            interactable.GetComponent<Animator>().Play("Bookshelf");
        }

        ////Parkour lever
        //if (playerInZone && manager.leverOn == false && Input.GetKeyDown(KeyCode.E))           
        //{
        //    //gameObject.GetComponent<AudioSource>().Play();
        //    gameObject.GetComponent<Animator>().Play("lever");
        //    manager.leverOn = true;
        //    StartCoroutine(SpawnPlatforms());

        //}
    }

    private IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0.5f);

        interactable.GetComponent<Animator>().Play("Door");
    }

    private IEnumerator SpawnPlatforms()
    {
        yield return new WaitForSeconds(0.5f);

        manager.block.SetActive(!manager.block.activeSelf);

    }

    private void OnTriggerEnter(Collider other)
    {
        //If player is in zone
        if (other.gameObject.tag == "Player")
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

