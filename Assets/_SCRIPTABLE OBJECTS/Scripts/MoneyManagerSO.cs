using UnityEngine;

[CreateAssetMenu(fileName = "New Money", menuName = "Money Actions/Money Manager")]
public class MoneyManagerSO : ScriptableObject
{
    private bool _canMoneyIncrease;
    private bool _canPassiveIncome;

    private int _moneyIncreaseUpgrade = 1;
    private int _moneyAmount = 1;

    public int MoneyAmount //Makes this variable public while maintaining security with private _moneyAmount variable
    {
        get { return _moneyAmount; }
        private set { _moneyAmount = value; }
    }

    public void MoneyIncrease(int moneyAmount, bool canIncreaseMoneyCount)
    {
        if (canIncreaseMoneyCount)
        {
            _moneyIncreaseUpgrade = 2;
        }

        MoneyAmount += moneyAmount * _moneyIncreaseUpgrade;

        if (_moneyAmount <= 0)
        {
            _moneyAmount = 0;
        }
    }

    public void ResetMoneyCount()
    {
        _moneyAmount = 1;
        _moneyIncreaseUpgrade = 1;
    }
}
