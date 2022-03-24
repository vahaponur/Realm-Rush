using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// Represents Enemy Movement Behaviour
/// </summary>
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] [Range(0f, 4f)] private float _speed = 1f;

    #endregion

    #region Private Fields

    /// <summary>
    /// Path of enemy
    /// </summary>
    private List<Waypoint> _path;

    private Enemy _enemyMain;

    #endregion

    #region Public Properties

    #endregion

    #region MonoBehaveMethods

    private void Awake()
    {
        _enemyMain = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    #endregion

    #region PublicMethods

    #endregion

    #region PrivateMethods

    /// <summary>
    /// Enemy follows path by moving with given seconds between tiles
    /// </summary>
    /// <returns>Null</returns>
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in _path)
        {
            Vector3 startPos = transform.position;
            float travelPercent = 0f;
            transform.LookAt(waypoint.transform.position);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(startPos, waypoint.transform.position, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        ProcessFinishPath();
    }

    /// <summary>
    /// Finds the path for enemy on the current level
    /// </summary>
    void FindPath()
    {
        var pathObjects = GameObject.FindGameObjectWithTag("Path").transform.GetAllChildGameObjects();
        _path = pathObjects.GetComponentAll<Waypoint>().ToList();
    }

    /// <summary>
    /// Set position of the enemy to first point of the path
    /// </summary>
    void ReturnToStart()
    {
        transform.position = _path[0].transform.position;
    }

    /// <summary>
    /// Calls the events if enemy successfully finishes the path
    /// </summary>
    void ProcessFinishPath()
    {
        _enemyMain.GivePenalty();
        gameObject.SetActive(false);
    }

    #endregion
}