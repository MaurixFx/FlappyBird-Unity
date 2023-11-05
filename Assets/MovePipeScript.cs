using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipeScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    public LogicManagerScript logic;

    // Start is called before the first frame update
    void Start()
    {
        // FindGameObjectWithTag helps to find gameobject with tag
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isGameActive)
        {
            // EASY
            if (logic.playerScore < 8)
            {
                moveSpeed = 10;
            }
            // NORMAL
            else if (logic.playerScore >= 8 && logic.playerScore < 20)
            {
                moveSpeed = 15;
            }
            // HARD
            else
            {
                moveSpeed = 18;
            }

            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

            if (transform.position.x < deadZone)
            {
                Destroy(gameObject);
            }
        }
    }
}
