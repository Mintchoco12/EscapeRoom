using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Manager manager;

    private bool PlayerInZone;           

    public GameObject block;
    public GameObject block1;

    private bool leverOn;

    private void Start()
    {
        leverOn = false;
        PlayerInZone = false;              
    }

    private void Update()
    {
        //If player is in zone of lever and e is pressed
        if (PlayerInZone && leverOn == false && Input.GetKeyDown(KeyCode.E))           
        {
            leverOn = true;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("lever");
            StartCoroutine(SpawnBridge());
            StartCoroutine(DestroyWall());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Detects the player
        if (other.gameObject.tag == "Player")    
        {
            PlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)     
    {
        //Detects the player
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
        }
    }

    IEnumerator SpawnBridge()
    {
        yield return new WaitForSeconds(0.8f);

        //Spawn platform when lever is pulled
        block.SetActive(!block.activeSelf);
        manager.stage[4] = true;
    }

    IEnumerator DestroyWall()
    {
        yield return new WaitForSeconds(0.8f);

        //Destroy wall when lever is pulled
        block1.SetActive(false);
    }

}
