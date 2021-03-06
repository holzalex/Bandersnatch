﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFlip : MonoBehaviour
{
    public AIPath aiPath;
    
    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector2(-4f, 4f);
        } 
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector2(4f, 4f);
        }
    }
}
