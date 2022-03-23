using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents Day & Night Cycle
/// </summary>
public class DNCycle : MonoBehaviour
{
    #region Serialized Fields
    [Tooltip("Speed of the sun rotation, more mean long day cycle")]
    [Range(10, 200)][SerializeField] float _speed;

    [Tooltip("Percentage of the night in a cycle")]
    [Range(0.1f, 0.9f)][SerializeField] float _nightRate = 0.5f;
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    
    void Update()
    {
        transform.Rotate(Vector3.right * _speed * CycleRate() * Time.deltaTime);
    }
    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods
    
    /// <summary>
    /// Returns speed of the sun based on day night rate
    /// </summary>
    /// <returns>Speed of sun</returns>
    float CycleRate()
    {
       return transform.rotation.eulerAngles.x > 180 ? 1f - _nightRate : _nightRate;
    }

   
    #endregion
}
