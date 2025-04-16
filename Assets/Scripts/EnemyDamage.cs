using Assets.Enemy.Scripts;
using Assets.Enemy.Scripts.EnemyExample;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    GlobalController _controller;
  


    private void Start()
    {
        _controller = GlobalController.instance;

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _controller.DecreaseHealth((new EnemyBase(1, 1)).Damage);
        }
        if (other.CompareTag("Enemyfast"))
        { 
            _controller.DecreaseHealth((new Mantis(1, 1)).Damage);

        }
        if (other.CompareTag("Enemyslow"))
        {
            _controller.DecreaseHealth(_controller.enemySlowDamage);
        }
    }
}
