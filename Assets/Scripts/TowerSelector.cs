using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TowerSelector : MonoBehaviour
{
    public static TowerSelector instance;
    public bool spawnMode = false;
    public GameObject[] towers;
    public GameObject activeTower;
    public GameObject previewTower;
    public TowerSpawning floor;
    private TowerSpawning floorScript;
    public GameObject notEnoughCoins;
    public GameObject cannotPlace;
    public TextMeshPro coinsText;
    public float coins;
    public bool canSpawn;


    public void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        floorScript = floor;
    }
    private void Update()
    {
        coinsText.text = coins.ToString();

        if (spawnMode && SceneManager.GetActiveScene().name != "ProdSceneButterNewMap")
        {
            var dropRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool cast = Physics.Raycast(dropRay.origin, dropRay.direction, out var hit, 9999, 1 << 6);
            var succHit = hit.point;
            //succHit.y += 2.1225f;
            previewTower.transform.position = cast ? succHit : new Vector3(69, 69, 69);
        }
        else if(spawnMode)
        {
            var dropRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool cast = Physics.Raycast(dropRay.origin, dropRay.direction, out var hit, 9999, 1 << 10);
            var succHit = hit.point;
            succHit.y += 1.1225f;
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
        if (coins >= activeTower.GetComponent<TowerFunction>().TowerValue && SceneManager.GetActiveScene().name != "ProdSceneButterNewMap")
        {
            spawnMode = true;
            print(activeTower.gameObject.name);
            previewTower = Instantiate(activeTower, floorScript.worldPosition, transform.rotation);
            previewTower.transform.Rotate(-28, 0, 0);
            previewTower.tag = "PreviewTower";
            previewTower.GetComponent<TowerFunction>().enabled = false;
        }
        else if (coins >= activeTower.GetComponent<TowerFunction>().TowerValue)
        {
            spawnMode = true;
            print(activeTower.gameObject.name);
            previewTower = Instantiate(activeTower);
            previewTower.transform.Rotate(-28, 0, 0);
            previewTower.transform.localScale *= 0.5f;
            previewTower.tag = "PreviewTower";
            previewTower.GetComponent<TowerFunction>().enabled = false;
        }
        else
        {
            print("You cannot afford this!");
            notEnoughCoins.gameObject.SetActive(true);
            StartCoroutine("Feedback");
        }
    }

    public IEnumerator Feedback()
    {
        yield return new WaitForSeconds(1.5f);

        notEnoughCoins.gameObject.SetActive(false);
        cannotPlace.gameObject.SetActive(false);
    }
}
