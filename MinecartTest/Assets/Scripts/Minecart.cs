using System;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    [SerializeField] private GameObject _endGoal;
    private float _moveSpeed = 1f;
    private bool _canMove = true;

    private Rigidbody2D _rb;

    private const float _MIN_DISTANCE_TO_END_GOAL = 0.2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _canMove = true;
        GameManager.OnMaxTimeReached += GameManager_OnMaxTimeReached;
    }

    private void Update()
    {
        if (_canMove)
        {
            Move(Vector2.right);
        }

        if (Vector3.Distance(transform.position, _endGoal.transform.position) <= _MIN_DISTANCE_TO_END_GOAL)
        {
            _canMove = false;
            transform.position = _endGoal.transform.position;
        }
    }

    private void Move(Vector2 direction)
    {
        Vector2 myPosition = _rb.position;
        myPosition += _moveSpeed * direction * Time.deltaTime;

        _rb.MovePosition(myPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _canMove = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _canMove = true;
    }

    private void GameManager_OnMaxTimeReached(object sender, EventArgs e)
    {
        _canMove = false;
    }
}
