//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Chests : MonoBehaviour
//{
//    [SerializeField] private GameObject chestLock;
//    [SerializeField] private GameObject key;

//    public bool lockUnlocked;
//    public bool keyInHand;

//    private void Start()
//    {

//    }

//    public void OpenFirstChest()
//    {
//        manager.stage[1] = true;
//        keyInHand = true;
//    }

//    public void OpenSecondChest()
//    {
//        manager.stage[3] = true;
//    }

//    public void UnlockLock()
//    {
//        Destroy(chestLock);
//        Destroy(key);
//        lockUnlocked = true;
//        manager.stage[2] = true;
//    }
//}
