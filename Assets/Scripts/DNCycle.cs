using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Awake()
    {

    }

    void Start()
    {

    }


    void Update()
    {

        var timeMultiplier = 1f;
        timeMultiplier = transform.rotation.eulerAngles.x > 180 ? 1f - _nightRate : _nightRate;

        transform.Rotate(Vector3.right * _speed * timeMultiplier * Time.deltaTime);
    }
    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods
    #endregion
}
