using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy: MonoBehaviour
{
    Transform enemyTransform;
    Player player = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        enemyTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < this.transform.position.x)
        {
            enemyTransform.Translate(-0.04f, 0, 0);
        }
        else if (player.transform.position.x > this.transform.position.x)
        {
            enemyTransform.Translate(0.04f, 0, 0);
        }

        if (player.transform.position.z < this.transform.position.z)
        {
            enemyTransform.Translate(0, 0, -0.04f);
        }
        else if (player.transform.position.z > this.transform.position.z)
        {
            enemyTransform.Translate(0, 0, 0.04f);
        }

            if (this.gameObject.transform.position.y <= 0)
        {
            transform.position += new Vector3(0,10,0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hit"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
