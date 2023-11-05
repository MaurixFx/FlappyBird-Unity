using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2.0f;
    private float timer = 0;
    public float heightOffset = 10;
    public LogicManagerScript logic;

    // Start is called before the first frame update
    void Start()
    {
        // FindGameObjectWithTag helps to find gameobject with tag
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isGameActive) {
            // EASY
            if (logic.playerScore < 8)
            {
                spawnRate = 2.0f;
            }
            // NORMAL
            else if (logic.playerScore >= 8 && logic.playerScore < 20)
            {
                spawnRate = 1.5f;
            }
            // HARD
            else
            {
                spawnRate = 1f;
            }

            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timer = 0;
            }
        }  
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
