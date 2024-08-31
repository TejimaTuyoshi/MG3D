using UnityEngine;
using UnityEngine.UI;

public class FPSText : MonoBehaviour
{
    [SerializeField] Text text;

    int frameCount;
    float prevTime;
    float fps;
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }
    // XVˆ—
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            text.text = $"FPS:{fps}";

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}
