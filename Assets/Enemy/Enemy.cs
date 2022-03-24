using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private int goldReward = 25;
    [SerializeField] private int goldPenalty = 25;

    #endregion

    #region Private Fields

    private Bank _bank;

    #endregion

    #region Public Properties

    #endregion

    #region MonoBehaveMethods
    void Start()
    {
        _bank = FindObjectOfType<Bank>();
    }

    #endregion

    #region PublicMethods

    #endregion

    #region PrivateMethods
    /// <summary>
    /// Gives reward to player by depositing gold
    /// </summary>
    public void GiveReward()
    {
        if (_bank == null) return;
        _bank.Deposit(goldReward);
    }
    /// <summary>
    /// Gives penalty to player by withdrawing gold
    /// </summary>
    public void GivePenalty()
    {
        if (_bank == null) return;
        bool isGameOver = !_bank.Withdraw(goldPenalty);
        if (isGameOver)
        {
            SceneManagerAdapter.ReloadLevel();
        }
    }
    #endregion
}