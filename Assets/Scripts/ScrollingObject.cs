using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D bg_rb2d;

    void Start()
    {
        bg_rb2d = GetComponent<Rigidbody2D>();
        bg_rb2d.velocity = new Vector2(GameController.instance.scroll_speed, 0);
    }

    void Update()
    {
        if (GameController.instance.game_over)
        {
            bg_rb2d.velocity = Vector2.zero;
        }
    }
}
