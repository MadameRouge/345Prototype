using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int Spawned = 0;
    public int Defeated = 0;
    public GameObject stairs;
    // Update is called once per frame
    private void Start()
    {
        stairs.SetActive(false);
    }
    public void SpawnedCount()
    {
        Spawned += 1;
    }
    public void DefeatedCount()
    {
        Defeated += 1;
        if (Defeated >= Spawned)
        {
            Debug.Log("Player has defeated all enemies.");
            stairs.SetActive(true);
        }
    }
}
