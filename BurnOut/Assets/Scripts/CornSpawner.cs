using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Inflammable _cornPrefab;
    [SerializeField] private int _cornCount;
    private Inflammable[] _corns;
    [SerializeField] private float _randomness;
    [SerializeField] private float _delay;
    private float _time;
    private int _index;
    // Start is called before the first frame update
    void Start()
    {
        _time = _delay;
        _corns = new Inflammable[_cornCount];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _time)
        {
            _time = Time.time + _delay;
            SpawnCorn();
        }
    }

    private void SpawnCorn()
    {
        Inflammable corn = _corns[_index];
        if (!corn)
        {
            corn = Instantiate(_cornPrefab);
            _corns[_index] = corn;
        }
        corn.Init();
        float x = Random.Range(-_randomness, _randomness);
        float z = Random.Range(-_randomness, _randomness);

        corn.transform.position = _spawnPoint.position + new Vector3(x, 0, z);
        _index = (_index + 1) % _corns.Length;
    }
}
