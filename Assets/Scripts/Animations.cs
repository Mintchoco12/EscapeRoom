using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{       
    [SerializeField] private Manager manager;
    [SerializeField] private GameObject interactable;

    private bool playerInZone;
    
    private void Start()
    {
        playerInZone = false;
    }

    private void Update()
    {
        //Move bookshelf
        if (playerInZone && manager.amphoraInHand && Input.GetMouseButton(1))
        {
            manager.amphoraInPlace = true;
            manager.amphoraInHand = false;
            StartCoroutine(MoveBookshelf());
        }

        //Open lock
        if (playerInZone && manager.keyInHand && Input.GetMouseButtonDown(0))
        {
            manager.UnlockLock();
        }

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
            StartCoroutine(OpenDoor());
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

    private IEnumerator MoveBookshelf()
    {
        yield return new WaitForSeconds(0.5f);

        interactable.GetComponent<Animator>().Play("Bookshelf");
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
        }
    }
}

