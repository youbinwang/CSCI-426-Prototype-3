using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public GameObject colorGray;
    public GameObject colorObjects1;
    public GameObject colorObjects2;
    
    public Color color1 = new Color(0.13f, 0.74f, 0.94f);
    public Color color2 = new Color(0.94f, 0.54f, 0.12f);
    public Color grayColor = new Color(0.275f, 0.275f, 0.275f);
    
    public enum ColorState { Gray, Color1, Color2 }
    private List<ColorState> availableColors = new List<ColorState> { ColorState.Gray, ColorState.Color1 };
    private int currentColorIndex = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchColor();
        }
    }

    void SwitchColor()
    {
        if (availableColors.Count > 1)
        {
            currentColorIndex = (currentColorIndex + 1) % availableColors.Count;
            UpdateWorldState();
        }
    }
    
    void UpdateWorldState()
    {
        ColorState currentState = availableColors[currentColorIndex];
        
        switch (currentState)
        {
            case ColorState.Gray:
            default:
                Camera.main.backgroundColor = grayColor;
                colorGray.SetActive(false);
                colorObjects1.SetActive(true);
                colorObjects2.SetActive(true);
                break;
        
            case ColorState.Color1:
                Camera.main.backgroundColor = color1;
                colorObjects2.SetActive(false);
                colorObjects1.SetActive(true);
                colorGray.SetActive(true);
                
                break;
        
            case ColorState.Color2:
                Camera.main.backgroundColor = color2;
                colorObjects1.SetActive(false);
                colorObjects2.SetActive(true);
                colorGray.SetActive(true);
                
                break;
        }
    }
    
    public void ActivateColor(ColorState color)
    {
        if (!availableColors.Contains(color))
        {
            availableColors.Add(color);
        }
    }
}
