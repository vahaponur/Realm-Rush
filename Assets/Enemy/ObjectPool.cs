using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPool : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField][Range(0,50)] private int _poolSize;
    [SerializeField] [Range(0.1f,30f)] private float _spawnTimer = 1f;
    #endregion

    #region Private Fields

    private GameObject[] _pool;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
	    ProducePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

   
    void Update()
    {
        
    }
    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableNextObject();
           
            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    void EnableNextObject()
    {
        foreach (var enemy in _pool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                break;
            }
        }
    }
    void ProducePool()
    {
        _pool = new GameObject[_poolSize];
        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(_enemyPrefab, transform);
        }
        _pool.DisableAll();
    }
    
    #endregion
}
