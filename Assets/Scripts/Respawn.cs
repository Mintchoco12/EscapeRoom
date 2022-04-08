using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    void OnTriggerEnter(Collider other)
    {
        //player.GetComponent<FirstPersonController>().enabled = false;
        player.transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();
        print(respawnPoint.transform.position);
        //player.GetComponent<FirstPersonController>().enabled = true;

    }

}
