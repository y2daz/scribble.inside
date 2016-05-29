using UnityEngine;
using System.Collections;

public class LerpColor : MonoBehaviour
{
    public Color[] c;
    Color color;
    float t = 0;
    float i = 0.025f;
    bool change = false;

    void Awake()
    {
        color = c[0];
    }

    void Update()
    {
        GetComponent<Renderer>().material.color = Color.Lerp(c[0], c[1], t);
        if (!change)
            t += i;
        else
            t -= i;
        if (t >= 1)
            change = true;
        if (t <= 0)
            change = false;
    }
}