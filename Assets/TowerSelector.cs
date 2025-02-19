using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public bool spawnMode = false;
    public GameObject[] towers;
    public GameObject activeTower;
    public GameObject previewTower;
    public GameObject floor;
    private TowerSpawning floorScript;
    public int coins;

    public void Start()
    {
        floorScript = floor.GetComponent<TowerSpawning>();
    }
    private void Update()
    {
        if (spawnMode)
        {
            previewTower.gameObject.transform.position = floorScript.worldPosition;
        }

    }
    public void TowerSelect(string tower)
    {
        switch (tower)
        {
            case "red":
                activeTower = towers[0];
                break;
            case "blue":
                activeTower = towers[1];
                break;
            case "yellow":
                activeTower = towers[2];
                break;
            case "pink":
                activeTower = towers[3];
                break;
            default:
                print("No tower selected");
                break;
        }
        if (coins >= activeTower.GetComponent<TowerManager>().towerCost)
        {
            spawnMode = true;
            print(activeTower.gameObject.name);
            previewTower = Instantiate(activeTower, floorScript.worldPosition, transform.rotation);
            previewTower.transform.Rotate(90, 0, 0);
            previewTower.GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            print("You cannot afford this!");
        }
    }
}
