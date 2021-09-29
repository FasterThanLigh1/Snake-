using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject fruits;
    int horizontalBound = 14;
    int verticalBound = 4;
    SnakeMovement snake;
    void Start()
    {
        Spawn(1);
        snake = GameObject.Find("Snake").GetComponent<SnakeMovement>();
    }
    void Update()
    {
        if(snake.Spawn)
        {
            Spawn(1);
            print("point increase");
            snake.Spawn = false;
        }
    }

    void Spawn(int number)
    {
        for(int i = 0; i < number; i++)
        {
            int randX = Random.Range(-horizontalBound, horizontalBound + 1);
            int randY = Random.Range(-verticalBound, verticalBound + 1);
            Vector2 spawnPos = new Vector2(randX, randY);
            Instantiate(fruits, spawnPos, fruits.gameObject.transform.rotation);
        }
    }
}
