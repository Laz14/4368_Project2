using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    private Image HealthBarImage;

    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        HealthBarImage.color = Color.red;
    }

    public void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
    }
}
