using UnityEngine;

public class ObjectDisappearanceAnomalyType : MonoBehaviour, IAnomaly
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