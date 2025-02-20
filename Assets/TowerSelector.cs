using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public static TowerSelector instance;
    public bool spawnMode = false;
    public GameObject[] towers;
    public GameObject activeTower;
    public GameObject previewTower;
    public GameObject floor;
    private TowerSpawning floorScript;
    public int coins;

    public void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        floorScript = floor.GetComponent<TowerSpawning>();
    }
    private void Update()
    {
        if (spawnMode)
        {
            var dropRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool cast = Physics.Raycast(dropRay.origin, dropRay.direction, out var hit, 9999, 1 << 6);
            var succHit = hit.point;
            previewTower.transform.position = cast ? succHit : new Vector3(69, 69, 69);
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
