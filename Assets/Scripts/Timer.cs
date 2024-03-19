using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Text;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject timerblocker;

    private static Timer instance;

    public static Timer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Timer>();
                instance.StartSingleton();
            }

            return instance;
        }
    }


    public TMP_Text timerText;
    private float starTime;

    private int milliseconds;
    private int seconds;
    private int minutes;

    public float time { get; set; }
    public bool stopTimer { get; set; }

    private static readonly string[] digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ":", "." };
    private static readonly StringBuilder timer = new StringBuilder(8);

    private void StartSingleton()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update () {

        if (GameManager.Instance.gameover)
            return;

        if (timerblocker)
            return;

        time += Time.deltaTime;
        var oldMillisecond = milliseconds;

        minutes = (int)(time / 60f) % 60;
        seconds = (int)(time % 60);
        milliseconds = (int)(time * 100f) % 100;

        if (milliseconds != oldMillisecond)
        {
            timer.Length = 0;
            timer.Append(digits[minutes / 10]);
            timer.Append(digits[minutes % 10]);
            timer.Append(digits[10]);
            timer.Append(digits[seconds / 10]);
            timer.Append(digits[seconds % 10]);
            timer.Append(digits[11]);
            timer.Append(digits[milliseconds / 10]);
            timer.Append(digits[milliseconds % 10]);
            timerText.text = timer.ToString();
        }


    }
}
