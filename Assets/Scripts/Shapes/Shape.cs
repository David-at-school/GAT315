using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    public abstract float Size { get; set; }
    public abstract float Area { get; }

    public float Mass => Area * Density;
    public float Density { get; set; } = 1;
}
