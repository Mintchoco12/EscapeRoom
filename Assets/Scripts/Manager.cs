using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private string amphoraTag = "Amphora";
    [SerializeField] private string keyTag = "Key";
    [SerializeField] private GameObject amphora;

    public List<GameObject> chestGameobjects = new List<GameObject>();
    public List<bool> stage = new List<bool>();
    public GameObject block;

    public bool chestUnlocked;
    public bool leverOn;

    public bool amphoraInHand;
    public bool keyInHand;
    public bool amphoraInPlace;

    private Transform _selection;

    private void Start()
    {
        for (int i = 0; i < stage.Count; i++)
        {
            stage[i] = false;
        }
        leverOn = false;
        chestUnlocked = false;

        amphoraInHand = false;
        keyInHand = false;
        amphoraInPlace = false;
    }

    private void Update()
    {
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

        if (amphoraInPlace)
        {
            amphora.transform.position = new Vector3(1.2f, 10.85f, -5.55f);
            amphora.transform.eulerAngles = Vector3.up * 90;
        }
    }

    public void UnlockLock()
    {
        Destroy(chestGameobjects[1]);
        Destroy(chestGameobjects[2]);
        //keyInHand = false;
        chestUnlocked = true;
        stage[1] = true;
    }

    public IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1);

        stage[2] = true;
    }
}
