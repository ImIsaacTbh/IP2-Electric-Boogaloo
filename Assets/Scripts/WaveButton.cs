using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveButton : MonoBehaviour
{
    void Update()
    {
        if (GlobalController.instance._isWaveInProgress)
        {
            GetComponent<Image>().color = new Color(1, 1, 0);
        }
        else
        {
            GetComponent<Image>().color = new Color(0, 1, 0);
        }
    }
}
