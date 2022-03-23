using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private int _maxHitPoints = 5;
    #endregion

    #region Private Fields

    private int _currentHitPoints = 0;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods

    private void Start()
    {
        _currentHitPoints = _maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        
    }
    
    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods

    void ProcessHit()
    {
        _currentHitPoints--;
        if (_currentHitPoints < 1)
        {
            Destroy(gameObject);
        }
    }

    

    #endregion
}
