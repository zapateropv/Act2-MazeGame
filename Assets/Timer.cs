using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TMP_Text timerText;

    void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timeLeft).ToString();
        }
        else
        {
            timeLeft = 0;
            timerText.text = "0";
        }
    }
}