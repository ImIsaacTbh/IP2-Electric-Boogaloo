using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider col)
    {
        //if colides with Player tag respawn
        if(col.gameObject.tag == "Player")
        {
            CharacterController cc = col.GetComponent<CharacterController>();

            cc.enabled = false;
            col.gameObject.transform.position = spawnPoint.position;
            cc.enabled = true;
        }
    }
}
