using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkeleton : Enemy
{
    // Start is called before the first frame update
     protected override void Introduction()
    {
        //base.Introduction();
        Debug.Log("Rizz"); 
    }
    
    void Start()
    {
        base.Attack();
    }

    // Update is called once per frame
    void Update()
    {
        base.Animate();
    }
}
