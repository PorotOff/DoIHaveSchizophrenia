using UnityEngine.SceneManagement;

public class SceneNavigationByButton : NavigationByButton
{
    protected override void Go()
    {
        SceneManager.LoadScene(index);
    }
}