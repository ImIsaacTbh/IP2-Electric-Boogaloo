using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public PlayerHealth Damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator LifetimeExpiry()
    {
        //destroys game object for the bullets after 3 secs
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
            //destroyees the bullets hwne the hit the player and do damage
            Destroy(gameObject);
            Damage.TakeDamage(10);
        }
    }
}
