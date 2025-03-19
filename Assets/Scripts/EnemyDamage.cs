using Assets.Enemy.Scripts;
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
            _controller.DecreaseHealth(_controller.enemyDamage);
        }
        if (other.CompareTag("Enemyfast"))
        {
            _controller.DecreaseHealth(_controller.enemyFastDamage);

        }
        if (other.CompareTag("Enemyslow"))
        {
            _controller.DecreaseHealth(_controller.enemySlowDamage);
        }
    }
}
