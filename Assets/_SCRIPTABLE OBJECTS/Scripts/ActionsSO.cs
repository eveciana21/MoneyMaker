using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "New Money Action", menuName = "Money Actions/Actions")]
public class ActionsSO : ScriptableObject
{
    public UnityAction OnClickToEarnClicked;

    public UnityAction OnUpgradeClicked;

    public UnityAction OnPassiveEarningClicked;
    public Action HidePassiveEarningsButton;

    public UnityAction OnIncreaseEarningsClicked;
    public Action HideIncreaseEarningsButton;

    public Action ShowUpgradesOptions;
    public Action HideUpgradesOptions;

    public UnityAction OnBackButtonClicked;

    public UnityAction OnRetireButtonClicked;
    public Action ShowRetireButton;

    public UnityAction OnQuitGame;


    public void ClickToEarn()
    {
        OnClickToEarnClicked?.Invoke();
    }

    public void UpgradeClicked()
    {
        OnUpgradeClicked?.Invoke();
    }

    public void PassiveEarningsClicked()
    {
        OnPassiveEarningClicked?.Invoke();
    }

    public void IncreaseEarningsClicked()
    {
        OnIncreaseEarningsClicked?.Invoke();
    }

    public void BackButtonClicked()
    {
        OnBackButtonClicked?.Invoke();
    }

    public void RetireButtonClicked()
    {
        OnRetireButtonClicked?.Invoke();
    }

    public void QuitGame()
    {
        OnQuitGame?.Invoke();
    }
}
