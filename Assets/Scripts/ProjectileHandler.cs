using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Enemy.Scripts;
using Assets.Enemy.Scripts.EnemyExample;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public int dmg;
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            Enemy c = enemy.GetComponents<Component>().FirstOrDefault(x => x.GetType().IsSubclassOf(typeof(Enemy))) as Enemy;
            c.Health -= dmg;
        }
    }
}
