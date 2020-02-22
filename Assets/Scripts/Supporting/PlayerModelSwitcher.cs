using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSwitcher : MonoBehaviour
{
    [SerializeField] GameObject[] playerModels = null;

    void Start()
    {
        foreach(GameObject go in playerModels)
        {
            go.SetActive(false);
        }

        int rand = Random.Range(0, playerModels.Length);

        playerModels[rand].SetActive(true);
    }
}
