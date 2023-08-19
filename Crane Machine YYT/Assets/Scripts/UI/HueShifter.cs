using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HueShifter : MonoBehaviour
{
    public float Speed = 1;
    [SerializeField] private Image rend;
    [SerializeField] private float Saturation;
    [SerializeField] private float Value;
 
    private void Update()
    {
        rend.color = Color.HSVToRGB(Mathf.PingPong(Time.time * Speed, 1), Saturation, Value);

        //rend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor( Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
    }
}
