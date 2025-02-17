using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float move = 0.02f;
    Transform enemyTransform;
    Player player = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        enemyTransform = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        enemyTransform.Translate(0, 0, move);
    }
}
