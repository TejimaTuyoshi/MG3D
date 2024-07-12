using UnityEngine;
using UnityEngine.UIElements;

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
        Transform myTransform = this.transform;
        // ローカル座標を基準に、座標を取得
        Vector3 localPos = myTransform.localPosition;
        if (Input.GetKey("a") && !isStop)
        {
            if (isJump)
            {
                myTransform.Translate(0, 0, 0.02f);
            }
            else
            {
                myTransform.Translate(0, 0, 0.05f);
            }
        }
        if (Input.GetKey("d") && !isStop)
        {
            if (isJump)
            {
                myTransform.Translate(0, 0, -0.02f);
            }
            else
            {
                myTransform.Translate(0, 0, -0.05f);
            }
        }

        if (Input.GetKey("w") && !isStop)
        {
            if (isJump)
            {
                myTransform.Translate(0.02f, 0, 0);
            }
            else
            {
                myTransform.Translate(0.05f, 0, 0);
            }
        }
        if (Input.GetKey("s") && !isStop)
        {
            if (isJump)
            {
                myTransform.Translate(-0.02f, 0, 0);
            }
            else
            {
                myTransform.Translate(-0.05f, 0, 0);
            }
        }
        if (Input.GetKey("j") && !isStop)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey("i") && !isStop)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey("k") && !isStop)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey("l") && !isStop)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown("space") && !isStop)
        {
            isJump = true;
            rigidBody.AddForce(Vector3.up * 500, ForceMode.Force);
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
