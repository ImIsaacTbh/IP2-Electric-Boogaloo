using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverScale : MonoBehaviour
{
    public void OnMouseEnter()
    {
        transform.localScale = new Vector2(1.25f, 1.25f); //Scales up the buton
        
    }
    public void OnMouseExit()
    {
        transform.localScale = new Vector2(1f, 1f); //returns the button to its normal size
    }
}
