using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public int force;
    public GameObject[] bulletHolePrefab;

    public int currentAmmo = 5;
    public int maxAmmo = 20;
    public bool currentlyReloading = false;
    public Text ammoDisplay;

    public float range = 100f;
    public Camera cam;
    public float fireRate = 0.99f; // Adjust as needed
    public bool canFire = true;

    //recoil
    public Recoil Recoil_Script;
    public bool aiming;
    public int damage = 10;

    void Start()
    {
        maxAmmo = currentAmmo;

        //Recoil_Script = transform.Find("CameraRot/CameraRecoil").GetComponent<Recoil>();
    }

    private void Update()
    {
        //if games paused doesnt do this code
        if (PauseMenu.instance.isPaused == false)
        {

            ammoDisplay.text = currentAmmo.ToString();
            //reaload when amo empty
            if (currentAmmo < 1) StartCoroutine(Reload());
            //reload when r is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }

            if (Input.GetButton("Fire2")) aiming = true;
            else aiming = false;

            if (!currentlyReloading && canFire && Input.GetButton("Fire1") && Time.timeScale == 1)
            {
                print("bang");
                Shoot();
                canFire = false;
                fireRate = 0.1f; // Reset the fire rate
            }
            if (fireRate <= 0.0f)
            {
                canFire = true;
            }

            // Decrement the fire rate timer
            fireRate -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        currentAmmo--;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit))
        {
            //makes teh bullet hole
            GameObject chosenBulletHole = bulletHolePrefab[Random.Range(0, bulletHolePrefab.Length)];

            var tempBullet = Instantiate(chosenBulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            tempBullet.transform.parent = hit.transform;


            if (hit.transform.gameObject.tag == "ForceAffected")
                //makes cubes move
            {
                var direction = new Vector3(
                hit.transform.position.x - transform.position.x,
                hit.transform.position.y - transform.position.y,
                hit.transform.position.z - transform.position.z);

                hit.rigidbody.AddForceAtPosition(force * Vector3.Normalize(direction), hit.point);
            }
            //enemy takes damage
         var hitBox = hit.collider.GetComponent<HitBox>();
            if (hitBox)
            {
                hitBox.OnRaycastHit(this);
            }
        }

        Recoil_Script.RecoilFire(); //put this next to animation in the future

    }



    IEnumerator Reload()
    {
        //if reloading 
        currentlyReloading = true;
        yield return new WaitForSeconds(1);
        currentAmmo = maxAmmo;
        currentlyReloading = false;
        print("reloaded");
    }
}