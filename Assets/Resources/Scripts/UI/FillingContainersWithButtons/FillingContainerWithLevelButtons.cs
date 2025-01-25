using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.UI;
using System.Collections.Generic;

public class FillingContainerWithLevelButtons : FillingContainerWithButtons
{
    private LevelListConfig levelListConfig;

    public void Initialise(LevelListConfig levelListConfig)
    {
        this.levelListConfig = levelListConfig;

        FillWithLocalizedButtons();
    }

    protected override IEnumerable<object> GetItems()
    {
        return levelListConfig.levelConfigs;
    }

    protected override LocalizedString GetLocalizedString(object item)
    {
        var level = item as LevelConfig;
        return new LocalizedString
        {
            TableReference = "LevelNames",
            TableEntryReference = level?.LocalizationKey
        };
    }

    protected override void OnButtonClick(object item)
    {
        var level = item as LevelConfig;
        SceneManager.LoadScene(level?.Scene.name);
    }
}