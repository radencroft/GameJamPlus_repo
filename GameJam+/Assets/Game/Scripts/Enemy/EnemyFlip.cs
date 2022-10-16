using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFlip : MonoBehaviour
{
    private Vector3 scale;
    public AIPath aiPath;

    private void Start()
    {
        scale = transform.localScale;
    }

    private void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
    }
}
