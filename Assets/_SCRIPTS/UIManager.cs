using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ActionsSO _actionsSO;
    [SerializeField] private MoneyManagerSO _moneyManagerSO;
    [SerializeField] private AnimationsSO _animationsSO;

    [SerializeField] private Button _passiveEarningsButton;
    [SerializeField] private Button _increaseEarningsButton;
    [SerializeField] private Button _retireButton;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private GameObject _upgradesPopup;

    private int _upgradesObtained;
    private int _moneyAmount = 1;

    private bool _canIncreaseMoneyAmount = false;
    private bool _canPassiveIncome;
    private bool _increaseMoneyUpgradeActive;
    private bool _passiveIncomeUpgradeActive;

    private void Start()
    {
        if (_moneyManagerSO != null)
        {
            _moneyManagerSO.ResetMoneyCount();
            _moneyAmount = _moneyManagerSO.MoneyAmount;
            UpgradeMoneyText();
        }

        if (_increaseEarningsButton != null)
            _increaseEarningsButton.interactable = false;
        if (_passiveEarningsButton != null)
            _passiveEarningsButton.interactable = false;
    }

    #region OnEnable/OnDisable
    private void OnEnable()
    {
        if (_actionsSO != null)
        {
            _actionsSO.OnPassiveEarningClicked += PassiveIncomeButtonClicked;
            _actionsSO.OnIncreaseEarningsClicked += IncreaseEarningsClicked;
            _actionsSO.HidePassiveEarningsButton += HidePassiveEarningsButton;
            _actionsSO.HideIncreaseEarningsButton += HideIncreaseEarningsButton;
            _actionsSO.OnUpgradeClicked += ShowUpgradesPopup;
            _actionsSO.OnBackButtonClicked += HideUpgradesPopup;
            _actionsSO.OnClickToEarnClicked += AddToMoneyCount;
            _actionsSO.OnRetireButtonClicked += RetireButtonClicked;
        }
    }

    private void OnDisable()
    {
        if (_actionsSO != null)
        {
            _actionsSO.OnPassiveEarningClicked -= PassiveIncomeButtonClicked;
            _actionsSO.OnIncreaseEarningsClicked -= IncreaseEarningsClicked;
            _actionsSO.HidePassiveEarningsButton -= HidePassiveEarningsButton;
            _actionsSO.HideIncreaseEarningsButton -= HideIncreaseEarningsButton;
            _actionsSO.OnUpgradeClicked -= ShowUpgradesPopup;
            _actionsSO.OnBackButtonClicked -= HideUpgradesPopup;
            _actionsSO.OnClickToEarnClicked -= AddToMoneyCount;
            _actionsSO.OnRetireButtonClicked -= RetireButtonClicked;
        }
    }
    #endregion

    private void AddToMoneyCount()
    {
        if (_moneyManagerSO != null)
        {
            _moneyManagerSO?.MoneyIncrease(1, _increaseMoneyUpgradeActive);
            _moneyAmount = _moneyManagerSO.MoneyAmount;
            UpgradeMoneyText();
        }
    }

    private void ShowUpgradesPopup()
    {
        _upgradesPopup?.gameObject.SetActive(true);

        if (!_increaseMoneyUpgradeActive && _moneyAmount >= 50)
        {
            SetButtonInteractionState(_increaseEarningsButton, true);
            _canIncreaseMoneyAmount = true;
        }
        if (!_passiveIncomeUpgradeActive && _moneyAmount >= 100)
        {
            SetButtonInteractionState(_passiveEarningsButton, true);
            _canPassiveIncome = true;
        }
    }

    private void HideUpgradesPopup()
    {
        _animationsSO?.ResetLOLAnimation();
        _upgradesPopup?.gameObject.SetActive(false);

        if (_passiveIncomeUpgradeActive)
            HidePassiveEarningsButton();

        if (_increaseMoneyUpgradeActive)
            HideIncreaseEarningsButton();

        if (_upgradesObtained >= 2)
            ShowRetireButton();
    }

    private void IncreaseEarningsClicked()
    {
        if (_canIncreaseMoneyAmount)
        {
            _animationsSO?.Play100Animation();
            UpdateMoneyAndText(-50);
            _increaseMoneyUpgradeActive = true;
            _canIncreaseMoneyAmount = false;
        }

        SetButtonInteractionState(_increaseEarningsButton, false);
    }

    private void PassiveIncomeButtonClicked()
    {
        if (!_passiveIncomeUpgradeActive && _canPassiveIncome)
        {
            _animationsSO?.Play200Animation();
            UpdateMoneyAndText(-100);
            _passiveIncomeUpgradeActive = true;

            StartCoroutine(PassiveIncomeRoutine());
        }

        SetButtonInteractionState(_passiveEarningsButton, false);
    }

    private void UpdateMoneyAndText(int amount)
    {
        if (_moneyManagerSO != null)
        {
            _moneyManagerSO.MoneyIncrease(amount, true);
            _moneyAmount = _moneyManagerSO.MoneyAmount;
            UpgradeMoneyText();
            _upgradesObtained++;
        }
    }

    IEnumerator PassiveIncomeRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            _moneyAmount++;
            UpgradeMoneyText();
        }
    }

    private void SetButtonInteractionState(Button button, bool state)
    {
        if (button != null)
            button.interactable = state;
    }

    private void HidePassiveEarningsButton()
    {
        _passiveEarningsButton?.gameObject.SetActive(false);
    }

    private void HideIncreaseEarningsButton()
    {
        _increaseEarningsButton?.gameObject.SetActive(false);
    }

    private void ShowRetireButton()
    {
        _retireButton?.gameObject.SetActive(true);
    }

    private void RetireButtonClicked()
    {
        _animationsSO?.PlayLOLAnimation();
    }

    private void UpgradeMoneyText()
    {
        _moneyText.text = "$" + _moneyAmount.ToString();
    }
}
