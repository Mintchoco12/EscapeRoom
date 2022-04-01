using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    private new Animations animation;
    private PickUpItem pickUp;

    [SerializeField] private GameObject chestLock;
    [SerializeField] private GameObject key;

    public bool lockUnlocked;
    public bool keyInHand;

    private void Start()
    {
        animation = GetComponent<Animations>();
        pickUp = GetComponent<PickUpItem>();

        lockUnlocked = false;
        keyInHand = false;
    }

    public void OpenFirstChest()
    {
        animation.isOpen[1] = true;
        keyInHand = true;
    }

    public void OpenSecondChest()
    {
        animation.isOpen[3] = true;
    }

    public void UnlockLock()
    {
        Destroy(chestLock);
        Destroy(key);
        lockUnlocked = true;
        animation.isOpen[2] = true;
    }
}
