using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverQuit : MonoBehaviour
{
    public GameObject txtToDisplay;

    private bool PlayerInZone;

    private void Start()
    {
        PlayerInZone = false;
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        //if in zone and press E key
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            //Play lever animation
            gameObject.GetComponent<Animator>().Play("lever");
            StartCoroutine(QuitGame());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if player in zone
        if (other.gameObject.tag == "Player")
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //if player exit zone
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }

    //Coroutine for quitting game
    IEnumerator QuitGame()
    {
        //Wait for lever animation to play before quitting
        yield return new WaitForSeconds(0.8f);

        //Quit game when lever is pressed
        Application.Quit();
    }
}
