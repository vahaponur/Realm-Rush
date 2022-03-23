using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// Represents Enemy Movement Behaviour
/// </summary>
public class EnemyMover : MonoBehaviour
{
    #region Serialized Fields
  
    [Tooltip("Waypoints of enemy path")]
    [SerializeField] private List<Waypoint> _path;

    [SerializeField] [Range(0f,4f)] private float _speed = 1f;
    #endregion

    #region Private Fields

    private Waypoint _currentWaypoint;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
       
	
    }
   
    void Start()
    {
        FindPath();
        Coroutine prt = StartCoroutine(FollowPath());
    }

   
    void Update()
    {
        
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
    }
    
    /// <summary>
    /// Finds the path for enemy on the current level
    /// </summary>
    void FindPath()
    {
        var pathObjects = GameObject.Find("Path").transform.GetAllChildGameObjects();

        _path = pathObjects.GetComponentAll<Waypoint>().ToList();
    }
 
    #endregion
}
