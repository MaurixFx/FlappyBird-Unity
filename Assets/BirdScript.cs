using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float flapStrength;
    public LogicManagerScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        // FindGameObjectWithTag helps to find gameobject with tag
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            rigidBody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 17 || transform.position.y < -17)
        {
            logic.gameOver();
        }
    }

    // When the bird collision the pipes
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
