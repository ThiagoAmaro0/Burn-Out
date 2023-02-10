using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflammable : MonoBehaviour
{
    [SerializeField] private Material _burnedMaterial;

    private Renderer[] _renders;
    private void Start()
    {
        _renders = GetComponentsInChildren<Renderer>();
    }

    public void Burn()
    {
        foreach (Renderer render in _renders)
        {
            render.material = _burnedMaterial;
        }
    }


}
