using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeLine : MonoBehaviour
{
    public static RangeLine instance;
    public int subdivisions = 50;
    public float radius = 5f;
    public LineRenderer towerLineRenderer;
    public Material m_normal, m_red;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        towerLineRenderer = GameObject.FindGameObjectWithTag("PreviewTower").GetComponent<LineRenderer>();
        towerLineRenderer.material.color = Color.white;
    }

    void Update()
    {
        float angleStep = 2f * Mathf.PI / subdivisions;

        towerLineRenderer.positionCount = subdivisions;

        for (int i = 0; i < subdivisions; i++)
        {
            float xPosition = radius * Mathf.Cos(angleStep * i);
            float zPosition = radius * Mathf.Sin(angleStep * i);

            Vector3 pointInCircle = new Vector3(xPosition, 0f, zPosition);

            towerLineRenderer.SetPosition(i, pointInCircle);
        }
    }
}
