using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootstrap : MonoBehaviour
{
    [Header("Заполнение контейнера кнопками уровней")]
    [SerializeField] private FillingContainerWithLevelButtons levelButtonsFiller;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private LevelListConfig levelListConfig;

    private void Awake()
    {
        levelButtonsFiller.Initialise(buttonPrefab, levelListConfig);
    }
}