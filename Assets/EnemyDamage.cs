using Assets.Enemy.Scripts;
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
            _controller.DecreaseHealth(10);
        }
        if (other.CompareTag("Enemyfast"))
        {
            _controller.DecreaseHealth(5);

        }
        if (other.CompareTag("Enemyslow"))
        {
            _controller.DecreaseHealth(20);
        }
    }
}
