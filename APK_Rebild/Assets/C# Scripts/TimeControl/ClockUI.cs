using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private WorldClockSteps _worldClockSteps;
    [SerializeField] private Text _textClock;

    int hour = 24;

    private void Start()
    {
        WorldClockSteps.State3 += UIupdate;
        UIupdate();
    }
    void UIupdate()
    {
        hour++;
        if (hour >= 24)
            hour = 0;
        if (hour < 10)
            _textClock.text = "0" + hour.ToString() + " : 00";
        else
            _textClock.text = hour.ToString() + " : 00";
    }
}
