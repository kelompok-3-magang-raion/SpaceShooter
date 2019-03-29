using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeUI : MonoBehaviour
{
    public Image gaugeUI;
    public Text gaugeText;
    

    // Update is called once per frame
    void Update()
    {
        gaugeUI.GetComponent<RectTransform>().sizeDelta = new Vector2(Gabung.gauge*30, 20);
        if (Gabung.gauge  >= 6)
        {
            gaugeText.gameObject.SetActive(true);
            gaugeUI.color = Color.red;
        }
        else
        {
            gaugeText.gameObject.SetActive(false);
            gaugeUI.color = Color.white;
        }

        
    }
}
