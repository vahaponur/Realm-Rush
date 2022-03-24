using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private int _towerCost = 75;

    #endregion

    #region Private Fields

    private Bank _bank;

    #endregion

    #region Public Properties

    #endregion

    #region MonoBehaveMethods

    void Awake()
    {
    }

    void Start()
    {
        
    }


    void Update()
    {
    }

    #endregion

    #region PublicMethods

    public bool CreateTower(Tower tower, Vector3 position)
    {
        if (PayTowerBill())
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            return true;
        }

        return false;
    }

    #endregion

    #region PrivateMethods
    /// <summary>
    /// Pay tower price to place tower
    /// </summary>
    /// <returns>True if payment successfull </returns>
    bool PayTowerBill()
    {
        _bank = FindObjectOfType<Bank>();
        return _bank.Withdraw(_towerCost);
    }

    #endregion
}