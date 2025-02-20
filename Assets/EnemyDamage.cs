using Assets.Enemy.Scripts;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] private StatsController statsController;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            statsController.DecreaseHealth(10);
        }
        
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            statsController.IncreaseCurrency(10);

        }
    }


}
