using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurretScript : MonoBehaviour
{
    public Vector3 targetDir;
    public GameObject player;
    public float speed;
    public float maxFollowAngle;
    public float maxVisibilityDistance;
    public Image alertUI; // Reference to a UI Image element
    public MeshRenderer turretRenderer; // Reference to the turret's renderer
    public float shootDelay = 2.0f; // Time to wait before shooting
    private float shootTimer = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        alertUI.color = Color.green; // Initial color
        //turretRenderer = GetComponent<MeshRenderer>(); //removed this code because every time game starts it would reset
        turretRenderer.material.color = Color.green; // Initial color
    }

    void Update()
    {
        if (PlayerVisible() && PlayerWithinDistance())
        {
            targetDir = player.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, speed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            alertUI.color = Color.red; // Change color when targeting
            turretRenderer.material.color = Color.red; // Change color when targeting
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootDelay)
            {
                Shoot();
                shootTimer = 0.0f; // Reset timer after shooting
            }
        }
        else
        {
            alertUI.color = Color.green; // Default color
            turretRenderer.material.color = Color.gray; // Default color
            shootTimer = 0.0f; // Reset timer if player is not in range
        }
    }

    private bool PlayerVisible()
    {
        float dot = Vector3.Dot(transform.forward, (player.transform.position - transform.position).normalized);

        if (dot > maxFollowAngle)
            return true;
        else return false;
    }

    private bool PlayerWithinDistance()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < maxVisibilityDistance)
            return true;
        return false;
    }

    void Shoot()
    {
        // Implement shooting logic here
        Debug.Log("Turret shooting at player!");
    }
}
