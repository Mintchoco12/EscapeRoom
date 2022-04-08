using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private List<GameObject> checkPoints;
    //[SerializeField] private Vector3 vectorPoint;
    //[SerializeField] private float dead;

    private void Update()
    {
        ////If player y is lower then death position
        //if (player.transform.position.y < -dead)
        //{
        //    //Return player to previous checkpoint
        //    Physics.SyncTransforms();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //vectorPoint = player.transform.position;

        if (other.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(-19.107f, 11.278f, -20.227f);
        }
    }
}
