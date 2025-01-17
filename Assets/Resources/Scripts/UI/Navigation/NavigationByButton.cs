using UnityEngine.UI;

public class NavigationByButton : Navigation
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(Go);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(Go);
    }
}