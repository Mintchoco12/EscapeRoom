using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    private Manager manager;
    private new Animations animation;
    private PickUpItem pickUp;

    [SerializeField] private GameObject chestLock;
    [SerializeField] private GameObject key;

    public bool lockUnlocked;
    public bool keyInHand;

    private void Start()
    {
        for (int i = 0; i < i + 1; i++) new GameObject();

        manager = key.GetComponent<Manager>();
        animation = GetComponent<Animations>();
        pickUp = GetComponent<PickUpItem>();

        lockUnlocked = false;
        keyInHand = false;
    }

    public void OpenFirstChest()
    {
        manager.stage[1] = true;
        keyInHand = true;
    }

    public void OpenSecondChest()
    {
        manager.stage[3] = true;
    }

    public void UnlockLock()
    {
        Destroy(chestLock);
        Destroy(key);
        lockUnlocked = true;
        manager.stage[2] = true;
    }
}
