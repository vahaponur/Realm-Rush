using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Labels tile coordinates as 2D Cartesian Coordinate System
/// </summary>
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    TMP_Text _label;
    Vector2 _parentLocation = new Vector2Int();
    private string _locationStr;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
        _label = GetComponent<TMP_Text>();
    }

    void Start()
    {

    }


    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateParentName();

        }

    }
    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods
    /// <summary>
    /// Displays the coordinates on tile.
    /// </summary>
    void DisplayCoordinates()
    {
        _parentLocation.x = Mathf.RoundToInt( transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        _parentLocation.y = Mathf.RoundToInt( transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        _locationStr = $"({_parentLocation.x}, {_parentLocation.y})";
        _label.text = _locationStr;
    }

    void UpdateParentName()
    {
        transform.parent.gameObject.name = _parentLocation.ToString();

    }


    #endregion
}
