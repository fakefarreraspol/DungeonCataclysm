using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    // Start is called before the first frame update
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
