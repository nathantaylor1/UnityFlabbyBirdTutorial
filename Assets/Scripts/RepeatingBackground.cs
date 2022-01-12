using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public BoxCollider2D ground_collider;
    private float ground_hlength;




    void Start()
    {
        ground_hlength = ground_collider.size.x;
    }

    void Update()
    {
        if (transform.position.x < -ground_hlength)
            RepositionBackground();
    }

    private void RepositionBackground()
    {
        Vector2 ground_offset = new Vector2(ground_hlength * 2f, 0);
        transform.position = (Vector2)transform.position + ground_offset;
    }
}
