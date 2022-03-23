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

    [SerializeField] private GameObject _turretPrefab;

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
        Instantiate(_turretPrefab, transform.position, Quaternion.identity);
        isPlaceable = false;
    }

    #endregion
}