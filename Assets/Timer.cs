using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 90f;
    public TMP_Text timerText;

    void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
        UpdateTimerText();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
                timeLeft = 0;

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    public void AddTime(float seconds)
    {
        timeLeft += seconds;
    }
}