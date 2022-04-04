using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<GameObject> chestGameobjects = new List<GameObject>();

    public bool[] stage = new bool[3];
    public bool keyInHand;
    public bool chestUnlocked;

    private void Start()
    {
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i] = false;
        }
        keyInHand = false;
        chestUnlocked = false;
    }
    public void UnlockLock()
    {
        Destroy(chestGameobjects[1]);
        Destroy(chestGameobjects[2]);
        keyInHand = false;
        chestUnlocked = true;
        stage[1] = true;
    }

    public void OpenChest()
    {
        stage[2] = true;
        keyInHand = true;
    }

}
