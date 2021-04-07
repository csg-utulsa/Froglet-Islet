using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChangeScript : MonoBehaviour
{
    Color color;
    Text text;
    float colorTimer;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        text.color = new Color(Random.Range(0,175f) / 255f, 1f, Random.Range(0, 175f)/255f);
        colorTimer = Random.Range(0.3f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (colorTimer <= 0)
        {
            text.color = new Color(Random.Range(0, 175f) / 255f, 1f, Random.Range(0, 175f) / 255f);
            colorTimer = Random.Range(0.3f, 2f);
        }
        else
            colorTimer -= Time.deltaTime;
    }
}
