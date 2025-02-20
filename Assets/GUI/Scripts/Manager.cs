using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public bool paused;
    public Slider fovSlider;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    { 

        cam.fieldOfView = fovSlider.value;
    }
}
