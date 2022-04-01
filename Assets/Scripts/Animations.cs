using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private GameObject interactable;
    [SerializeField] private GameObject chestLock;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject textToDisplay;

    private bool[] isOpen = new bool[3];
    [SerializeField] private bool keyInHand;
    private bool playerInZone;
    
    private void Start()
    {
        for (int i = 0; i < isOpen.Length; i++)
        {
            isOpen[i] = false;
        }
        keyInHand = false;
        playerInZone = false;
        textToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && isOpen[0] == false && isOpen[1] && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("Button");
            StartCoroutine(OpenDoor());
        }

        if (playerInZone && isOpen[1] == false && Input.GetKeyDown(KeyCode.E))
        {
            interactable.GetComponent<Animator>().Play("Chest");
            isOpen[1] = true;
            if (isOpen[1])
            {
                keyInHand = true;
            }
        }

        if (playerInZone && keyInHand == true && Input.GetMouseButtonDown(0))
        {
            Destroy(chestLock);
            Destroy(key);
            isOpen[2] = true;
        }

        if (playerInZone && isOpen[2] && Input.GetKeyDown(KeyCode.E))
        {
            interactable.GetComponent<Animator>().Play("Chest"); 
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

