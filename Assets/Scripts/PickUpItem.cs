using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Rigidbody rigidBody;
    public new BoxCollider collider;
    public Transform player, container, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        if (!equipped)
        {
            rigidBody.isKinematic = false;
            collider.isTrigger = false;
        }
        if (equipped)
        {
            rigidBody.isKinematic = true;
            collider.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        //Check if Player is in range
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetMouseButtonDown(0) && !slotFull)
        {
            PickUp();
        }

        //Drop if equipped
        if (equipped && Input.GetMouseButtonDown(1)) 
        {
            Drop();
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make item child of camera
        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Enable kinematic RigidBody and make BoxCollider a trigger
        rigidBody.isKinematic = true;
        collider.isTrigger = true;
        rigidBody.freezeRotation = true;
    }

    public void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Object has same momentum with player
        rigidBody.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rigidBody.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rigidBody.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        //Disable kinematic RigidBody and make BoxCollider normal
        rigidBody.isKinematic = false;
        collider.isTrigger = false;
        rigidBody.freezeRotation = false;
    }
}
