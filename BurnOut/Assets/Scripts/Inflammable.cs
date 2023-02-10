using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Inflammable : MonoBehaviour
{
    [SerializeField] private Material _burnedMaterial;
    private bool _burned;
    private bool _scorer;
    private Renderer[] _renders;
    private Material[] _startMaterials;

    private void Start()
    {
        _renders = GetComponentsInChildren<Renderer>();
        _startMaterials = new Material[_renders.Length];
        for (int i = 0; i < _renders.Length; i++)
        {
            _startMaterials[i] = _renders[i].material;
        }
    }

    public void Burn()
    {
        if (_burned)
            return;

        _burned = true;
        if (_scorer)
        {
            ScoreManager.OnGetScore?.Invoke(-1);
            transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.5f, 3, 0);
        }
        foreach (Renderer render in _renders)
        {
            render.material = _burnedMaterial;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (_burned)
        {
            if (other.gameObject.TryGetComponent<Inflammable>(out Inflammable _obj))
            {
                _obj.Burn();
            }
        }
    }

    public void Init()
    {
        if (_renders == null)
        {
            _renders = GetComponentsInChildren<Renderer>();
            _startMaterials = new Material[_renders.Length];
            for (int i = 0; i < _renders.Length; i++)
            {
                _startMaterials[i] = _renders[i].material;
            }
        }

        _burned = false;
        for (int i = 0; i < _renders.Length; i++)
        {
            _renders[i].material = _startMaterials[i];
        }
    }
}
