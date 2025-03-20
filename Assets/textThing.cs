using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textThing : MonoBehaviour
{
    public class ScalerColorTextMeme : MonoBehaviour
    {
        private float baseScale = 1;

        void Update()
        {
            float scale = Mathf.Sin(Time.time) * baseScale;
            if (scale < 0) scale *= -1;
            transform.localScale = new Vector3(scale, scale, baseScale);
        }
    }
}
