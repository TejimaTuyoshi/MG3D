using UnityEngine;

public class Player : MonoBehaviour
{
    bool isStop = true;
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
            transform.position += transform.TransformDirection(Vector3.forward) * 0.5f;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey("d") && !isStop)
        {
            transform.position += transform.TransformDirection(Vector3.back) * 0.5f;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey("w") && !isStop)
        {
            transform.position += transform.TransformDirection(Vector3.right) * 0.5f;
        }
        if (Input.GetKey("s") && !isStop)
        {
            transform.position += transform.TransformDirection(Vector3.left) * 0.5f;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown("space") && !isStop)
        {
            rigidBody.AddForce(Vector3.up * 500, ForceMode.Force);
        }
    }

    public void start()
    {
        isStop = false;
        Time.timeScale = 1.0f;
    }
}
