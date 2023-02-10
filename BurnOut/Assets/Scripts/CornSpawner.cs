using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Inflammable[] _corns;
    [SerializeField] private float _randomness;
    [SerializeField] private float _delay;
    private float _time;
    private int _index;
    // Start is called before the first frame update
    void Start()
    {
        _time = _delay;
        foreach (Inflammable corn in _corns)
        {
            corn.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _time)
        {
            _time = Time.time + _delay;
            SpawnCorn(_corns[_index]);
            _index = (_index + 1) % _corns.Length;
        }
    }

    private void SpawnCorn(Inflammable corn)
    {
        corn.Init();
        float x = Random.Range(-_randomness, _randomness);
        float z = Random.Range(-_randomness, _randomness);
        corn.gameObject.SetActive(true);
        corn.transform.position = _spawnPoint.position + new Vector3(x, 0, z);
    }
}
