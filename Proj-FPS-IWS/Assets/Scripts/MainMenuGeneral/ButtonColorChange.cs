using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    public Button button;
    public Color colorToChange;
    private Color ogColor;
    private ColorBlock cb;

    void Start()
    {
        cb = button.colors;
        ogColor = cb.selectedColor;
    }

    void Update()
    {
        
    }

    public void ChangeWhenHover() 
    {
        cb.selectedColor = colorToChange;
        button.colors = cb;
    }

    public void ChangeWhenOff()
    {
        cb.selectedColor = ogColor;
        button.colors = cb;
    }
}
