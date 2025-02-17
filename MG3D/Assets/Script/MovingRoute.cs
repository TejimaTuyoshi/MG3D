using UnityEngine;


public class MovingRoute : MonoBehaviour
{
    [SerializeField] GameObject route;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            route.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
