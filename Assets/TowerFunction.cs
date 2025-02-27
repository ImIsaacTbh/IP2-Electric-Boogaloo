using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerMode
{
    Closest,
    Farthest,
    Weakest,
    Strongest,
    First,
    Last
}

public class TowerFunction : MonoBehaviour
{
    public GlobalController instance = null;
    public List<GameObject> inRangeEnemies = new List<GameObject>();
    public TowerMode mode;
    public GameObject projectile;
    public int TowerValue;
    // Start is called before the first frame update
    void Start()
    {
        instance = GlobalController.instance;
        instance.Events.TowerTick += OnTowerTick;
        projectile = transform.GetChild(1).gameObject;
    }

    void OnTowerTick(object sender, EventArgs e)
    {
        if (mode == TowerMode.Closest)
        {
            KeyValuePair<GameObject, float> closest = new KeyValuePair<GameObject, float>(null, Mathf.Infinity);
            foreach (GameObject g in inRangeEnemies)
            {
                try
                {
                    if (Vector3.Distance(gameObject.transform.position, g.transform.position) is float distance &&
                        distance < closest.Value)
                    {
                        closest = new KeyValuePair<GameObject, float>(g, distance);
                    }
                }
                catch
                {
                    inRangeEnemies.Remove(g);
                }
            }
            if (closest.Key != null)
            {
                //Instantiate(projectile);
            }

            inRangeEnemies.Remove(closest.Key);
            try
            {
                Destroy(closest.Key);
            }
            catch
            {
                inRangeEnemies.Remove(closest.Key);
                print("Tried to destroy null object");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRangeEnemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRangeEnemies.Remove(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
