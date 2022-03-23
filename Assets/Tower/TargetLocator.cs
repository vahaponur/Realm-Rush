using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Acquires targets, fires the weapon
/// </summary>
public class TargetLocator : MonoBehaviour
{
    #region Serialized Fields
    [Tooltip("Head of the turret")]
    [SerializeField] private Transform weapon;
    #endregion

    #region Private Fields
    private Transform target;

    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
	
    }

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

   
    void Update()
    {
        AimWeapon();
    }
    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods

    void AimWeapon()
    {
       weapon.LookAt(target);
    }
    #endregion
}
