using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<GameObject> chestGameobjects = new List<GameObject>();
    public List<bool> stage = new List<bool>();
    public GameObject block;

    public bool keyInHand;
    public bool chestUnlocked;

    public bool leverOn;

    private void Start()
    {
        for (int i = 0; i < stage.Count; i++)
        {
            stage[i] = false;
        }
        keyInHand = false;
        leverOn = false;
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

    public IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1);

        stage[2] = true;
    }
}
