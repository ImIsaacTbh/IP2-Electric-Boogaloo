using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets;
using Assets.Enemy.Scripts;
using Assets.Enemy.Scripts.EnemyExample;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.AI;

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
    public float firerate = 1f;
    public int TowerValue;
    public float Damage;
    public float Range = 5f;

    private Vector3 projSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        instance = GlobalController.instance;
        instance.Events.TowerTick += OnTowerTick;
        projectile = transform.GetChild(1).gameObject;
        projSpawnPos = transform.GetChild(2).gameObject.transform.position;
    }
    int tickCount = 0;
    void OnTowerTick(object sender, EventArgs e)
    {
        tickCount++;
        if (tickCount % firerate != 0) return;
        if (mode == TowerMode.Closest)
        {
            KeyValuePair<GameObject, float> closest = new KeyValuePair<GameObject, float>(null, Mathf.Infinity);
            try
            {
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
            }
#pragma warning disable CS0168
            catch (InvalidOperationException ex)
#pragma warning restore CS0168
            {
            }

            if (closest.Key != null)
            {
                transform.LookAt(closest.Key.transform);
                if (ProjMotion)
                {
#warning make mortar
                    print("firing bullet");
                    GameObject proj = Instantiate(projectile);
                    proj.transform.position = projSpawnPos;
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
                    print("shooting the thing");
                    GameObject proj = Instantiate(projectile);
                    proj.transform.position = transform.position;
                    proj.AddComponent<StandardBullet>().target = closest.Key;
                    proj.GetComponent<StandardBullet>().sender = this;
                    proj.SetActive(true);
                }
            }
        }
        else if (mode == TowerMode.Last)
        {
            GameObject closest;
            List<GameObject> list = new List<GameObject>();
            foreach (GameObject g in inRangeEnemies)
            {
                list.Add(g);
            }
            list.Sort((x, y) => x.GetComponent<NavMeshAgent>().remainingDistance.CompareTo(y.GetComponent<NavMeshAgent>().remainingDistance));
            closest = list.First();
            if (ProjMotion)
            {
                print("firing bullet");
                GameObject proj = Instantiate(projectile);
                proj.transform.position = projSpawnPos;
                proj.layer = 8;
                Rigidbody rb = proj.GetComponentInChildren<Rigidbody>();
                Vector3 target = closest.transform.position;

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
                GameObject proj = Instantiate(projectile);
                proj.AddComponent<StandardBullet>().target = closest;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject g in EnemyController.instance._enemiesInPlay)
        {
            if (Vector3.Distance(g.transform.position, transform.position) <= Range)
            {
                if (!inRangeEnemies.Contains(g))
                {
                    print("added enemy to list");
                    inRangeEnemies.Add(g);
                }
            }
            else
            {
                try
                {
                    inRangeEnemies.Remove(g);
                }
                catch
                { }

            }
        }
    }
}

public class LookForward : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }
}

public class StandardBullet : MonoBehaviour
{
    public GameObject target;
    public TowerFunction sender;
    private void Update()
    {
        transform.position += (target.transform.position - transform.position).normalized * Time.deltaTime * 100;
    }

    void OnTriggerEnter(Collider c)
    {
        try
        {
            if (c.tag.Contains("Enemy") && c.tag != "EnemyKillVolume")
            {
                Enemy t = c.GetComponent<Enemy>();

                t.Health -= sender.Damage;
                if (t.Health < 0)
                {
                    TowerSelector.instance.coins += t.Cost;
                    Destroy(c.gameObject);
                }
                Destroy(this.gameObject);
            }
        }
        catch (MissingReferenceException ex)
        {
            Destroy(this.gameObject);
        }
        
    }
}
