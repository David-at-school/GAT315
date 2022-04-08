using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public enum eForceMode
    {
        ACCELERATION,
        FORCE,
        VELOCITY
    }

    public enum eBodyType
    {
        STATIC,
        KINEMATIC,
        DYNAMIC
    }
    public Shape shape;

    public eBodyType bodyType { get; set; } = eBodyType.DYNAMIC;
    public Vector2 position { get => transform.position; set => transform.position = value; }
    public Vector2 velocity { get; set; } = Vector2.zero;
    public Vector2 acceleration { get; set; } = Vector2.zero;
    public Vector2 force { get; set; } = Vector2.zero;
    public float mass => shape.Mass;
    public float inverseMass { get => (mass == 0 || bodyType != eBodyType.DYNAMIC) ? 0 : 1 / mass; }
    public float drag { get; set; } = 2.0f;

    public void ApplyForce(Vector2 force, eForceMode mode)
    {
        if (bodyType != eBodyType.DYNAMIC) return;

        switch (mode)
        {
            case eForceMode.ACCELERATION:
                acceleration += force;
                break;
            case eForceMode.FORCE:
                acceleration += force * inverseMass;
                break;
            case eForceMode.VELOCITY:
                velocity = force;
                break;
            default:
                break;
        }
    }

    public void Step(float dt)
    {
        //acceleration = Simulator.Instance.gravity + force * inverseMass;
    }
}
