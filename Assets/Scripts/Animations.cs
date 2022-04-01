using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{ 
    private Chests chest;
    private PickUpItem pickUp;

    [SerializeField] private GameObject interactable;
    [SerializeField] private GameObject textToDisplay;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject lockChest;

    public bool[] isOpen = new bool[4];
    private bool playerInZone;
    
    private void Start()
    {
        chest = lockChest.GetComponent<Chests>();
        pickUp = key.GetComponent<PickUpItem>();

        for (int i = 0; i < isOpen.Length; i++)
        {
            isOpen[i] = false;
        }
        playerInZone = false;
        textToDisplay.SetActive(false);
    }

    private void Update()
    {
        //Open door
        if (playerInZone && isOpen[0] == false && isOpen[1] && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("Button");
            StartCoroutine(OpenDoor());
        }

        //Open first chest
        if (playerInZone && isOpen[1] == false && Input.GetKeyDown(KeyCode.E))
        {
            interactable.GetComponent<Animator>().Play("Chest");
            chest.OpenFirstChest();
        }

        //Open lock
        if (playerInZone && pickUp.equipped && Input.GetMouseButtonDown(0))
        {
            chest.UnlockLock();
            print("test");
        }

        //Open second chest
        if (playerInZone && chest.lockUnlocked && Input.GetKeyDown(KeyCode.E))
        {
            interactable.GetComponent<Animator>().Play("Chest"); 
            chest.OpenSecondChest();
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0.5f);

        isOpen[0] = true;
        interactable.GetComponent<Animator>().Play("Door1");
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player is in zone
        if (other.gameObject.tag == "Player" && isOpen[0] == false)
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

