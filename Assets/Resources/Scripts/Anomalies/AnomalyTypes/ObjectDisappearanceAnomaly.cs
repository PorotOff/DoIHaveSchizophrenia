using UnityEngine;

public class ObjectDisappearanceAnomaly : MonoBehaviour, IAnomaly
{
    public void Occur()
    {
        gameObject.SetActive(false);
    }

    public void Fix()
    {
        gameObject.SetActive(true);
    }
}