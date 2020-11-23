using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    private Image HealthBarImage;
    static Color _color = Color.red;

    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        HealthBarImage.color = _color;
    }

    public void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
    }
}
