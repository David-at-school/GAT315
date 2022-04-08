using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShape : Shape
{
    public override float Size { get => transform.localScale.x; set => transform.localScale = Vector2.one * value; }
    public override float Area => radius * radius * Mathf.PI;

    public float radius => Size * 0.5f;
}
