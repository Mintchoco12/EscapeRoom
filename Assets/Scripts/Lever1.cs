using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI

public class Lever1 : MonoBehaviour
{
    public GameObject txtToDisplay;             //display the UI text

    private bool PlayerInZone;                  //check if the player is in trigger

    public GameObject block;
    public GameObject block1;

    private bool leverOn;

    private void Start()
    {
        leverOn = false;
        PlayerInZone = false;                   //player not in zone       
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && leverOn == false && Input.GetKeyDown(KeyCode.E))           //if in zone and press F key
        {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("lever");
            leverOn = true;
            txtToDisplay.SetActive(false);
            StartCoroutine(SpawnBridge());
            StartCoroutine(DestroyWall());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }
    IEnumerator SpawnBridge()
    {
        yield return new WaitForSeconds(0.8f);

        //Quit game when lever is pressed
        block.SetActive(!block.activeSelf);


    }
    IEnumerator DestroyWall()
    {
        yield return new WaitForSeconds(0.8f);

        //Quit game when lever is pressed
        block1.SetActive(false);


    }

}
