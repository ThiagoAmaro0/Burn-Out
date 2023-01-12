using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private const float GRAVITYFORCE = 7;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = -transform.position.normalized;
        _rigidBody.AddForce(dir * GRAVITYFORCE * _rigidBody.mass);
    }
}
