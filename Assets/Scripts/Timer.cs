using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timer = 0;
    public TextMeshProUGUI textTimer;

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        textTimer.text = timer.ToString("f2");  

    }
}
