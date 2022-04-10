using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private string amphoraTag = "Amphora";
    [SerializeField] private string keyTag = "Key";
    [SerializeField] private GameObject amphora;
    [SerializeField] private PickUpItem pickUp;

    public List<bool> stage = new List<bool>();
    public List<GameObject> chestGameobjects = new List<GameObject>();

    public bool chestUnlocked;

    public bool keyInHand;
    public bool amphoraInHand;
    public bool amphoraInPlace;

    private Transform _selection;

    private void Start()
    {
        for (int i = 0; i < stage.Count; i++)
        {
            stage[i] = false;
        }
        chestUnlocked = false;

        amphoraInHand = false;
        keyInHand = false;
        amphoraInPlace = false;
    }

    private void Update()
    {
        //Raycast for selecting objects
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(amphoraTag) && Input.GetMouseButton(0))
            {
                amphoraInHand = true;

                _selection = selection;
            }
            else if (amphoraInHand && Input.GetMouseButton(1))
            {
                amphoraInHand = false;
            }

            if (selection.CompareTag(keyTag) && Input.GetMouseButton(0))
            {
                keyInHand = true;

                _selection = selection;
            }
            else if (keyInHand && Input.GetMouseButton(1))
            {
                keyInHand = false;
            }
        }

        //Amphora puzzle that moves the bookshelf when completed
        if (amphoraInPlace)
        {
            amphora.transform.position = new Vector3(1.2f, 10.85f, -5.55f);
            amphora.transform.eulerAngles = Vector3.up * 90;
            pickUp.Drop();
            stage[2] = true;
        }
    }

    //Unlocks the lock on the chest
    public void UnlockLock()
    {
        pickUp.Drop();
        Destroy(chestGameobjects[1]);
        Destroy(chestGameobjects[2]);
        keyInHand = false;
        chestUnlocked = true;
        stage[0] = true;
    }

    //Coroutine for opening chest
    public IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1);

        stage[1] = true;
    }
}
