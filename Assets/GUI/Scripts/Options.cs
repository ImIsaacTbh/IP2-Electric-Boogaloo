using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic;

public class Options : MonoBehaviour
{

    public static List<int> widths = new List<int>() {1920, 1600, 1280, 960};
    public static List<int> heights = new List<int>() {1080, 900, 720, 540};

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);

    }

    public void SetFullScreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

}

