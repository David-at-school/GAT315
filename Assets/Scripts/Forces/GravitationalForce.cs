using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalForce : Force
{
    [SerializeField] FloatData gravition;

    public override void ApplyForce(List<Body> bodies)
    {
        for (int i = 0; i < bodies.Count; i++)
        {
            //for (int j = 0; j < bodies.Count; j++)
            for (int j = i + 1; j < bodies.Count; j++)
            {
                //if (i == j) continue;

                Body bodyA = bodies[i];
                Body bodyB = bodies[j];

                Vector2 direction = bodyA.position - bodyB.position;
                float distanceSqr = Mathf.Max(1, direction.sqrMagnitude);

                float force = gravition.value * (bodyA.mass * bodyB.mass) / distanceSqr;

                bodyA.ApplyForce(-direction.normalized * force, Body.eForceMode.FORCE);
                bodyB.ApplyForce(direction.normalized * force, Body.eForceMode.FORCE);
            }
        }
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
