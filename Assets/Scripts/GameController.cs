using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject text_game_over;
    public bool game_over;
    public float scroll_speed = -1.5f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);
    }

    private void Start() {
        game_over = false;
        text_game_over.SetActive(false);
    }

    void Update()
    {
        if (game_over && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    }

    public int num_players = 2;
    private int num_dead = 0;
    public void BirdDied()
    {
        num_dead++;
        if (num_dead >= num_players) {
            text_game_over.SetActive(true);
            game_over = true;
        }
    }

}
