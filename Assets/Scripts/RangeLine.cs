using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeLine : MonoBehaviour
{
    public static RangeLine instance;
    public int subdivisions = 50;
    public float radius;
    public LineRenderer towerLineRenderer;
    public Material m_normal, m_red;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        radius = this.GetComponent<TowerFunction>().Range;
        towerLineRenderer = GameObject.FindGameObjectWithTag("PreviewTower").GetComponent<LineRenderer>();
        towerLineRenderer.material.color = Color.white;
    }

    void Update()
    {
        float angleStep = 2f * Mathf.PI / subdivisions;

        if (towerLineRenderer != null)
        {
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
}
