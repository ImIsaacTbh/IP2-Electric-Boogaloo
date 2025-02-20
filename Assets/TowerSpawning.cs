using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawning : MonoBehaviour
{
    public GameObject towerSelection;
    private TowerSelector towerSelector;
    public Vector3 mousePos;
    public Vector3 worldPosition;

    public void Start()
    {
        towerSelector = towerSelection.gameObject.GetComponent<TowerSelector>();
    }

    public void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 55;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void TowerPlace()
    {
        if (towerSelector.spawnMode)
        {
            int towerCost = towerSelector.previewTower.GetComponent<TowerManager>().towerCost;
            towerSelector.coins -= towerCost;

            Destroy(towerSelector.previewTower);
            var turret = Instantiate(towerSelector.activeTower, worldPosition, transform.rotation);

            towerSelector.spawnMode = false;
        }
    }
}
