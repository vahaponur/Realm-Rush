using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Acquires targets, fires the weapon
/// </summary>
public class TargetLocator : MonoBehaviour
{
    #region Serialized Fields

    [Tooltip("Head of the turret")] [SerializeField]
    private Transform weapon;

    [SerializeField] private float maxRange = 15f;
    [SerializeField] private ParticleSystem _bulletParticle;

    #endregion

    #region Private Fields

    private Transform target;

    #endregion

    #region Public Properties

    #endregion

    #region MonoBehaveMethods

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    #endregion

    #region PublicMethods

    #endregion

    #region PrivateMethods

    /// <summary>
    /// Aims weapon to target
    /// </summary>
    void AimWeapon()
    {
        if (target == null)
        {
            Attack(false);
            return;   
        }   
        weapon.LookAt(target);
        float targetDis = Vector3.Distance(transform.position, target.position);
        bool enemyOnRange = targetDis < maxRange;
        Attack(enemyOnRange);
        
    }

    /// <summary>
    /// Finds the closest target to weapon
    /// </summary>
    void FindClosestTarget()
    {
        var enemies = FindObjectsOfType<Enemy>();
        Transform currentClosest = null;
        float maxDistance = Mathf.Infinity;

        for (int i = 0; i < enemies.Length; i++)
        {
            float currentDis = (enemies[i].transform.position - transform.position).sqrMagnitude;
            if (currentDis < maxDistance)
            {
                maxDistance = currentDis;
                currentClosest = enemies[i].transform;
            }
        }

        target = currentClosest;
    }
    
    /// <summary>
    /// Opens or closes the particle emission depending target active or not
    /// </summary>
    /// <param name="isActive"></param>
    void Attack(bool isActive)
    {
        var emission = _bulletParticle.emission;
        emission.enabled = isActive;
    }
    #endregion
}