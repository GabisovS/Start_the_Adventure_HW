using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Item> _itemPrefabs;
    [SerializeField] private float _cooldown;

    private float _time;
    private int _minIndex = 0;

    public void SetSpawner()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            List<SpawnPoint> emptyPoint = GetEmptyPoint();

            if (emptyPoint.Count == 0)
            {
                _time = 0;
                return;
            }

            SpawnPoint spawnPoint = emptyPoint[Random.Range(_minIndex, emptyPoint.Count)];

            Item _itemPrefab = _itemPrefabs[Random.Range(_minIndex, _itemPrefabs.Count)];

            Item itemClone = Instantiate(_itemPrefab, spawnPoint.Position, _itemPrefab.transform.rotation, null);

            spawnPoint.Occypy(itemClone);

            _time = 0;
        }
    }

    private List<SpawnPoint> GetEmptyPoint()
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            if (spawnPoint.IsEmpty)
            {
                emptyPoints.Add(spawnPoint);
            }
        }

        return emptyPoints;
    }

}
