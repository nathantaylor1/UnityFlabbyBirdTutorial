using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int column_pool_size = 5;
    public GameObject column_prefab;
    public float spawn_rate = 4f;
    public float column_min = -1f;
    public float column_max = 3.5f;


    private GameObject[] columns;
    private Vector2 object_pool_position = new Vector2(-15f, -25f);
    private float time_since_spawn;
    private float spawn_x_pos = 10f;
    private int current_column = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[column_pool_size];
        for (int i = 0; i < column_pool_size; ++i)
            columns[i] = (GameObject)Instantiate(column_prefab, object_pool_position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        time_since_spawn += Time.deltaTime;
        if (!GameController.instance.game_over && time_since_spawn >= spawn_rate)
        {
            time_since_spawn = 0;
            float spawn_y_pos = Random.Range(column_min, column_max);
            columns[current_column].transform.position = new Vector2(spawn_x_pos, spawn_y_pos);
            current_column++;
            if (current_column >= column_pool_size)
                current_column = 0;
        }
    }
}
