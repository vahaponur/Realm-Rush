using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents attached gameobject as Waypoint
/// </summary>
public class Waypoint : MonoBehaviour
{
    #region Serialized Fields

    [Tooltip("Can player put a turrent on this tile?")] [SerializeField]
    private bool isPlaceable;

    [SerializeField] private Tower _turretPrefab;

    #endregion

    #region Private Fields

    #endregion

    #region Public Properties
    public bool IsPlaceable
    {
        get => isPlaceable;
    }
    #endregion

    #region MonoBehaveMethods

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            
            PlaceTurret();
        }
    }

    #endregion

    #region PublicMethods

    #endregion

    #region PrivateMethods
    /// <summary>
    /// Place tower on this tile if not already placed
    /// </summary>
    void PlaceTurret()
    {
        bool isPlaced = _turretPrefab.CreateTower(_turretPrefab,transform.position);
       
        isPlaceable = !isPlaced;
    }

    #endregion
}