using UnityEngine;
using UnityEngine.UI;

public class EnableObjectByButton : MonoBehaviour
{
    private Button button;

    [SerializeField] private GameObject nextObject;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(EnableNextObject);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(EnableNextObject);
    }

    private void EnableNextObject()
    {
        nextObject.SetActive(true);
    }
}