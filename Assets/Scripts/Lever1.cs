using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    /*public GameObject txtToDisplay;             *///display the UI text

    private bool PlayerInZone;                  //check if the player is in trigger

    public GameObject block;

    private void Start()
    {

        PlayerInZone = false;                   //player not in zone       
        //txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))           //if in zone and press F key
        {
            //gameObject.GetComponent<AudioSource>().Play();
            //gameObject.GetComponent<Animator>().Play("switch");

            StartCoroutine(SpawnBridge());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            //txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
            //txtToDisplay.SetActive(false);
        }
    }
    IEnumerator SpawnBridge()
    {
        yield return new WaitForSeconds(0.8f);

        //Quit game when lever is pressed
        block.SetActive(!block.activeSelf);

    }
}
