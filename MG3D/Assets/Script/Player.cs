using UnityEngine;

public class Player : MonoBehaviour
{
    bool isStop = true;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && !isStop)
        {
            transform.position += transform.TransformDirection(Vector3.forward) * 0.5f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey("d") && !isStop)
        {
            transform.position += transform.TransformDirection(Vector3.back) * 0.5f;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey("w") && !isStop)
        {
            transform.position += transform.TransformDirection(Vector3.right) * 0.5f;
        }
        if (Input.GetKey("s") && !isStop)
        {
            transform.position += transform.TransformDirection(Vector3.left) * 0.5f;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }

    private void FixedUpdate()
    {
        if (isStop)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void start()
    {
        isStop = false;
    }
}
