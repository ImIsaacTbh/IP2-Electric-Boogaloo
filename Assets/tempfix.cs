using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempfix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        gameObject.SetActive(true);
    }
}
