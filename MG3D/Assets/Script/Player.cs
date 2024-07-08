using UnityEngine;

public class Player : MonoBehaviour
{
    bool isStop = true;
    bool isJump = false;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey("a") && !isStop)
        {
            if (isJump)
            {
                rigidBody.velocity += new Vector3(0, 0, 0.2f);
            }
            else
            {
                rigidBody.velocity += new Vector3(0, 0, 0.5f);
            }
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey("d") && !isStop)
        {
            if (isJump)
            {
                rigidBody.velocity += new Vector3(0, 0, -0.2f);
            }
            else
            {
                rigidBody.velocity += new Vector3(0, 0, -0.5f);
            }
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey("w") && !isStop)
        {
            if (isJump)
            {
                rigidBody.velocity += new Vector3(0.2f, 0, 0);
            }
            else
            {
                rigidBody.velocity += new Vector3(0.5f, 0, 0);
            }
        }
        if (Input.GetKey("s") && !isStop)
        {
            if (isJump)
            {
                rigidBody.velocity += new Vector3(-0.2f, 0, 0);
            }
            else
            {
                rigidBody.velocity += new Vector3(-0.5f, 0, 0);
            }
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown("space") && !isStop)
        {
            isJump = true;
            rigidBody.velocity += new Vector3(0, 10, 0);
        }
    }

    public void start()
    {
        isStop = false;
        Time.timeScale = 1.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isJump = false;
        }
    }
}
