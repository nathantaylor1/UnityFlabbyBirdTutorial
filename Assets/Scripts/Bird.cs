using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{

    // Add a public keycode, so that each instance of a bird can have its own "Flap" Button
    public KeyCode _keycode = KeyCode.Mouse0;

    // a public variable to manage the height that the bird gains when flapping
    public float flap_height = 200f;
    // tracks whether the player is dead (has collided with something)
    private bool is_dead;
    // a variable to store the rigidbody attached to the bird
    private Rigidbody2D rb2d;
    // a variable to store the bird's animator to trigger animations
    private Animator anim;

    // Scoring:
    private int bird_score = 0;
    public Text score_text;

    private void update_score()
    {
        score_text.text = "Score: " + bird_score.ToString();
    }

    public void bird_scored() 
    {
        if (is_dead) return;
        bird_score++;
        update_score();
    }

    // Start is called before the first frame update
    void Start()
    {
        update_score();
        // at the beginning of the game the bird should be alive
        is_dead = false;
        // get the rigidbody attached to the bird
        rb2d = GetComponent<Rigidbody2D>();
        // get the animator attached to the bird
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player is not dead and clicks (click := flap)
        if (!is_dead) if (Input.GetKeyDown(_keycode)) {
            rb2d.velocity = Vector2.zero;                   // reset velocity
            rb2d.AddForce(new Vector2(0, flap_height));     // move bird up (flap)
            anim.SetTrigger("Flap");                        // Trigger Flap Animation
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (is_dead) return;
        // remove velocity from the bird if it is dead
        rb2d.velocity = Vector2.zero;
        // if player collides with anything, the player is now dead
        is_dead = true;
        // Trigger the die animation
        anim.SetTrigger("Die");
        // Tell the game controller that the bird died
        GameController.instance.BirdDied();
    }
}
