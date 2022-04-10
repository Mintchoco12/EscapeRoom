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
        if (playerInZone && manager.amphoraInHand && Input.GetKeyDown(KeyCode.E))
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
        if (playerInZone && manager.stage[0] && Input.GetKeyDown(KeyCode.E))
        {
            interactable.GetComponent<Animator>().Play("Chest");
            StartCoroutine(manager.OpenChest());
        }

        //Bookshelf lever
        if (playerInZone && manager.stage[1] && manager.stage[2] && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("lever");
            StartCoroutine(OpenDoor());
        }

        //End lever
        if (playerInZone && manager.stage[4] && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("lever");
            StartCoroutine(QuitGame());
        }

    }

    //Coroutine for moving bookshelf
    private IEnumerator MoveBookshelf()
    {
        yield return new WaitForSeconds(0.5f);

        interactable.GetComponent<Animator>().Play("Bookshelf");
    }

    //Coroutine for opening door
    private IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0.5f);

        interactable.GetComponent<Animator>().Play("Door");
        manager.stage[3] = true;
    }

    //Coroutine for quitting game
    IEnumerator QuitGame()
    {
        //Wait for lever animation to play before quitting
        yield return new WaitForSeconds(0.8f);

        //Quit game when lever is pressed
        Application.Quit();
        print("Game closed");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Detects the player
        if (other.gameObject.tag == "Player")
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Detects the player
        if (other.gameObject.tag == "Player")
        {
            playerInZone = false;
        }
    }
}

