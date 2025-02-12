using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooberSpawnerTEST : MonoBehaviour
{
    public GameObject gooberPrefab;

    private int shpeeeeed = 0;
    private void FixedUpdate()
    {
        shpeeeeed++;
        if (shpeeeeed == 10)
        {
            shpeeeeed = 0;
            Instantiate(gooberPrefab).transform.position = transform.position;
            
        }
    }
}
