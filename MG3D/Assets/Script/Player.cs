using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float normalMove = 0.08f;
    [SerializeField] bool isStop = true;
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
        if (Input.GetMouseButtonDown(0) && !isStop)
        {
            Debug.Log("Hit");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a") && !isStop)
        {
            myTransform.Translate(0, 0, normalMove);
        }
        if (Input.GetKey("d") && !isStop)
        {
            myTransform.Translate(0, 0, -normalMove);
        }

        if (Input.GetKey("w") && !isStop)
        {
            myTransform.Translate(normalMove, 0, 0);
        }
        if (Input.GetKey("s") && !isStop)
        {
            myTransform.Translate(-normalMove, 0, 0);
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

}
