using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    #region Serialized Fields
    [Tooltip("Needed number of hit to die")]
    [SerializeField] private int _maxHitPoints = 5;
    
    [Tooltip("Every time enemy die it max hit point increase by this amount")]
    [SerializeField] private int _durabilityIncrease = 1;

    [SerializeField] private Slider _healthBar;
    #endregion

    #region Private Fields

    private int _currentHitPoints = 0;

    private Enemy _enemyMain;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods

    private void Awake()
    {
        _enemyMain = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _currentHitPoints = _maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void LateUpdate()
    {
        UpdateHealthBar();
    }

    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods
    /// <summary>
    /// Processes tower hit to enemy
    /// </summary>
    void ProcessHit()
    {
        _currentHitPoints--;
        if (_currentHitPoints < 1)
        {
            //In case of death by tower, disable object and give player a reward
            gameObject.SetActive(false);
            _maxHitPoints += _durabilityIncrease;
            _enemyMain.GiveReward();
            
        }
    }

    void UpdateHealthBar()
    {
        float rate = ((float) _currentHitPoints) /  _maxHitPoints;
        _healthBar.value = rate;
    }

    #endregion
}
