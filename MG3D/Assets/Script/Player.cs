using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpMove = 0.06f;
    [SerializeField] float normalMove = 0.08f;
    bool isStop = true;
    bool isJump = false;
    Rigidbody rigidBody;
    [SerializeField] GameObject north;
    [SerializeField] GameObject south;
    [SerializeField] GameObject west;
    [SerializeField] GameObject east;
    Transform myTransform;
    Vector3 localPos;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Time.timeScale = 0.0f;
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        localPos = myTransform.localPosition;
        if (Input.GetKeyDown("space") && !isStop)
        {
            isJump = true;
            rigidBody.AddForce(Vector3.up * 500, ForceMode.Force);
        }
    }

    private void FixedUpdate()
    {
        // ローカル座標を基準に、座標を取得
        if (Input.GetKey("a") && !isStop)
        {
            if (isJump)
            {
                myTransform.Translate(0, 0, jumpMove);
            }
            else
            {
                myTransform.Translate(0, 0, normalMove);
            }
        }
        if (Input.GetKey("d") && !isStop)
        {
            if (isJump)
            {
                myTransform.Translate(0, 0, -jumpMove);
            }
            else
            {
                myTransform.Translate(0, 0, -normalMove);
            }
        }

        if (Input.GetKey("w") && !isStop)
        {
           if (isJump)
            {
                myTransform.Translate(jumpMove, 0, 0);
            }
            else
            {
                myTransform.Translate(normalMove, 0, 0);
            }
        }
        if (Input.GetKey("s") && !isStop)
        {
            if (isJump)
            {
                myTransform.Translate(-jumpMove, 0, 0);
            }
            else
            {
                myTransform.Translate(-normalMove, 0, 0);
            }
        }
        if (Input.GetKey("j") && !isStop)
        {
            west.SetActive(true);
            north.SetActive(false);
            south.SetActive(false);
            east.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey("i") && !isStop)
        {
            west.SetActive(false);
            north.SetActive(true);
            south.SetActive(false);
            east.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey("k") && !isStop)
        {
            west.SetActive(false);
            north.SetActive(false);
            south.SetActive(true);
            east.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey("l") && !isStop)
        {
            west.SetActive(false);
            north.SetActive(false);
            south.SetActive(false);
            east.SetActive(true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
        if (other.gameObject.CompareTag("Right"))
        {
            isJump = false;
            transform.position += transform.TransformDirection(Vector3.forward) * 0.5f;
        }
        if (other.gameObject.CompareTag("Left"))
        {
            isJump = false;
            transform.position += transform.TransformDirection(Vector3.back) * 0.5f;
        }
        if (other.gameObject.CompareTag("Back"))
        {
            isJump = false;
            transform.position += transform.TransformDirection(Vector3.right) * 0.5f;
        }
        if (other.gameObject.CompareTag("Flont"))
        {
            isJump = false;
            transform.position += transform.TransformDirection(Vector3.left) * 0.5f;
        }
    }
}
