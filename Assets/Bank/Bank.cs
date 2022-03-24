using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private int _startBalance = 150;
    [SerializeField] private TextMeshProUGUI _balanceUItext;
    #endregion

    #region Private Fields

    [SerializeField]private int _currentBalance;

    #endregion

    #region Public Properties

    public int CurrentBalance => _currentBalance;

    #endregion

    #region MonoBehaveMethods

    void Awake()
    {
        _currentBalance = _startBalance;
        UpdateText();
    }

    void Start()
    {
    }


    void Update()
    {
    }

    #endregion

    #region PublicMethods

    public bool Deposit(int amount)
    {
        bool okayToDeposit = amount > 0;
        if (okayToDeposit)
        {
            _currentBalance += amount;
            UpdateText();
            return true;
        }

        return false;
    }

    public bool Withdraw(int amount)
    {
        bool okayToWithdraw = (amount <= _currentBalance) && (amount > 0);
        if (!okayToWithdraw) return false;
        
        _currentBalance -= amount;
        UpdateText();
        return true;
    }

    #endregion

    #region PrivateMethods

    void UpdateText()
    {
        _balanceUItext.text = "Gold : " + _currentBalance;
    }
    #endregion
}