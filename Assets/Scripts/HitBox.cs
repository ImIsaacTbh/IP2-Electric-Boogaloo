using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public EnemyAiTutorial aiTut;
   
    // Start is called before the first frame update
    public void OnRaycastHit(Gun weapon) //looks for the raycast hit and makes the enmy take the damage
    {
        if (aiTut != null)
        {
            aiTut.TakenDamage(10);
        }
    }
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
