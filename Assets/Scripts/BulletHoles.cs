using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoles : MonoBehaviour
{
    public float bulletHoleTimer;
    public float bulletHoleTimerMax = 10.0f;

    // Update is called once per frame
    void Update()
    {
        bulletHoleTimer += Time.deltaTime;

        if (bulletHoleTimer > bulletHoleTimerMax)// waites for the timer then destroyes bullet hole
        {
            Destroy(gameObject);
        }
    }
}
