using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassicUI : MonoBehaviour
{
    Image UI;
    float changeTime = 0f;
    bool isChange = false;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        changeTime += Time.deltaTime;
        Debug.Log(changeTime);
        if (changeTime >= 5 && !isChange)
        {
            isChange = true;
            UI.color = Color.clear;
            changeTime = 0f;
        }

        if (changeTime >= 5 && isChange)
        {
            isChange = false;
            UI.color = Color.white;
            changeTime = 0f;
        }
    }
}
