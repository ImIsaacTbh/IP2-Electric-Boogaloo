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
    public bool ProjMotion;
    public float projMotionLaunchAngle;
    public string customBehaviour;
    public int TowerValue;

    private Vector3 projSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        instance = GlobalController.instance;
        instance.Events.TowerTick += OnTowerTick;
        projectile = transform.GetChild(1).gameObject;
        projSpawnPos = transform.GetChild(2).gameObject.transform.position;
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
                if (ProjMotion)
                {
                    print("firing bullet");
                    GameObject proj = Instantiate(projectile);
                    proj.transform.position = projSpawnPos;
                    proj.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                    proj.layer = 8;
                    Rigidbody rb = proj.GetComponentInChildren<Rigidbody>();
                    Vector3 target = closest.Key.transform.position;
                    
                    Vector3 direction = target - projSpawnPos;
                    float h = direction.y;
                    direction.y = 0;
                    float distance = direction.magnitude;
                    float a = projMotionLaunchAngle * Mathf.Deg2Rad;
                    direction.y = distance * Mathf.Tan(a);
                    distance += h / Mathf.Tan(a);

                    // Calculate the velocity
                    float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
                    rb.velocity = velocity * direction.normalized;

                    proj.AddComponent<LookForward>();
                    proj.SetActive(true);
                }
                else
                {
                    Destroy(closest.Key);
                }
            }
            
            
            // try
            // {
            //
            // }
            // catch
            // {
            //     inRangeEnemies.Remove(closest.Key);
            //     print("Tried to destroy null object");
            // }
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

public class LookForward : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }
}
