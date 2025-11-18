using UnityEngine;
using UnityEngine.InputSystem;

public class Bat : MonoBehaviour
{
    [SerializeField] private GameObject _minecart;
    private float _moveSpeed = 2f;

    private Rigidbody2D _rb;
    private bool _isHovered;

    private const float _MAX_DISTANCE_TO_MINECART = 1.2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isHovered && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_minecart.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(_minecart.transform.position, transform.position);

        if (distance >= _MAX_DISTANCE_TO_MINECART)
        {
            Move(direction);
        }
    }

    private void Move(Vector2 direction)
    {
        Vector2 myPosition = _rb.position;
        myPosition += _moveSpeed * direction * Time.deltaTime;

        _rb.MovePosition(myPosition);
    }

    private void OnMouseEnter()
    {
        _isHovered = true;
    }

    private void OnMouseExit()
    {
        _isHovered = false;
    }
}
