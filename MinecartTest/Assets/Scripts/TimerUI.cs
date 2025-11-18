using System;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerTextMesh;

    private void Start()
    {
        GameManager.OnMaxTimeReached += GameManager_OnMaxTimeReached;
    }

    private void GameManager_OnMaxTimeReached(object sender, EventArgs e)
    {
        _timerTextMesh.text = "<color=#ff0000>TIME IS UP!!!</color>";
    }

    private void Update()
    {
        float timeRemaining = GameManager.Instance.GetTimeRemaining();
        if (timeRemaining > 0)
        {
            _timerTextMesh.text = timeRemaining.ToString("00.0") + "s";
        }
    }
}
