using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableAreaScript : MonoBehaviour
{
    public static PlaceableAreaScript instance;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PreviewTower")
        {
            TowerSelector.instance.canSpawn = false;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "PreviewTower")
        {
            TowerSelector.instance.canSpawn = true;
        }
    }
}
