using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private ActionsSO _actionsSO;

    private void OnEnable()
    {
        _actionsSO.OnQuitGame += QuitGameSelected;
    }

    private void OnDisable()
    {
        _actionsSO.OnQuitGame -= QuitGameSelected;
    }

    public void QuitGameSelected()
    {
        Application.Quit();
    }
}
