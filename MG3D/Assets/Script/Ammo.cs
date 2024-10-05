using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    float x = 0f;
    float y = 0f;
    float z = 0f;
    float playerX = 0f;
    float playerY = 0f;
    float playerZ = 0f;
    float distanceX = 0f;
    float distanceY = 0f;
    float distanceZ = 0f;
    [SerializeField] float power = 0.02f;
    Player player;
    ScoreText scoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        scoreText = GameObject.FindObjectOfType<ScoreText>();
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        playerZ = player.transform.position.z;
        distanceX = playerX - x;
        distanceY = playerY - y;
        distanceZ = playerZ - z;
        if (distanceX < 0) { distanceX *= -1; }
        if (distanceY < 0) { distanceY *= -1; }
        if (distanceZ < 0) { distanceZ *= -1; }
    }

    void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector3.up) * power;
        Back();
    }

    public void Front()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * power;
    }
    public void Back()
    {
        transform.position += transform.TransformDirection(Vector3.back) * power;
    }
    public void Right()
    {
        transform.position += transform.TransformDirection(Vector3.right) * power;
    }
    public void Left()
    {
        transform.position += transform.TransformDirection(Vector3.left) * power;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            player.LifeMinus();
        }
    }
}
