using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class TowerSpawning : MonoBehaviour
{
    public GameObject towerSelection;
    public Vector3 mousePos;
    public Vector3 worldPosition;

    public void TowerPlace()
    {
        if (TowerSelector.instance.spawnMode && TowerSelector.instance.canSpawn)
        {
            int towerCost = TowerSelector.instance.previewTower.GetComponent<TowerFunction>().TowerValue;
            TowerSelector.instance.coins -= towerCost;

            Destroy(TowerSelector.instance.previewTower);
            var dropRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool cast = Physics.Raycast(dropRay.origin, dropRay.direction, out var hit, 9999, 1 << 6);
            var succHit = hit.point;

            var turret = Instantiate(TowerSelector.instance.activeTower, succHit, transform.rotation);
            TowerManager.instance.activeTowers.Add(turret);
            TowerSelector.instance.spawnMode = false;
            
        }
        else
        {
            TowerSelector.instance.spawnMode = false;
            Destroy(TowerSelector.instance.previewTower);

            TowerSelector.instance.canSpawn = true;

            TowerSelector.instance.cannotPlace.SetActive(true);
            TowerSelector.instance.StartCoroutine("Feedback");
        }
    }
}
