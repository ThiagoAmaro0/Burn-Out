using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private Vector3 _rotation;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddTorque(_rotation);
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        print(input);
        _rotation = new Vector3(input.y, 0, -input.x) * _rotationSpeed;
    }
}
