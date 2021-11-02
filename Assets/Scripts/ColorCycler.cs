using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycler : MonoBehaviour
{
    //Codes to chnage the background.
    public static ColorCycler instance;

    public Color[] colors;
    public float speed = 5;
    int currentIndex = 0;
    Camera camera;
    public bool shouldChange = false;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        camera = GetComponent<Camera>();
        currentIndex = 0;
        SetColor(colors[currentIndex]);

        InvokeRepeating("CycleColor", 8f,8f);
    }



    void Update()
    {

       

        if (shouldChange)
        {
            var startColor = camera.backgroundColor;
            var endColor = colors[0];

            if (currentIndex+1 < colors.Length)
            {
                endColor = colors[currentIndex + 1];
            }




            var newColor = Color.Lerp(startColor, endColor, Time.deltaTime * speed);
            SetColor(newColor);

            if (newColor==endColor)
            {
                shouldChange = false;
                if (currentIndex + 1 < colors.Length)
                {
                    currentIndex++;
                }
                else
                {
                    currentIndex = 0;
                }
            }
        }
    }

    public void SetColor(Color color)
    {
        camera.backgroundColor = color;
    }

    public void CycleColor()
    {
        shouldChange = true;
    }

    
}
