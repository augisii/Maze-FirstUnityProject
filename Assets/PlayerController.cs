using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody2D rigidbody;
    public Vector3 spawnPoint;
    public GameObject player;
    public GameObject replayButton;
    public string nextSceneName;
    public AudioClip jumpscareSound;
    public AudioSource audioSource;
    public GameObject levelString;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Square"))
        {
            SceneManager.LoadScene("Startscreen");
        }
        else if (collision.gameObject.name == "Jumpscare")
        {
            // Your existing code for jumpscare handling...
        }
        else if (collision.gameObject.name.Contains("EndGoal"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
