using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCount : MonoBehaviour
{
    private float time=0;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private GameObject timeSurvived;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer.text = "Time: " + (int)time;
    }
    public void PassTime()
    {
        timeSurvived.GetComponent<TextMeshProUGUI>().text = "Time Survived: " + (int)time;
    }

}
