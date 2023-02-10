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
        _rotation = new Vector3(input.y, 0, -input.x) * _rotationSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Inflammable>(out Inflammable _obj))
        {
            _obj.Burn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Marshmallow>(out Marshmallow _obj))
        {
            _obj.Collect();
        }
    }
}
