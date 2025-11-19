using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public static event EventHandler OnMaxTimeReached;

    private const float _MAX_TIME = 20f;
    private float _currentTime = 0f;
    private bool _hasFinished = false;
    private bool _minecartHasArrived = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Minecart.OnMinecartArrived += Minecart_OnMinecartArrived;
    }

    private void Update()
    {
        if (!_minecartHasArrived)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _MAX_TIME && !_hasFinished)
            {
                OnMaxTimeReached?.Invoke(this, EventArgs.Empty);
                _hasFinished = true;
            }
        }
    }

    public float GetTimeRemaining()
    {
        return _MAX_TIME - _currentTime;
    }

    private void Minecart_OnMinecartArrived(object sender, EventArgs e)
    {
        Debug.Log("Message arrived to GameManager");
        _minecartHasArrived = true;
    }
}
