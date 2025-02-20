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
        
    }
}
