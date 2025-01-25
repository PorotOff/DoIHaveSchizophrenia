using System.Collections.Generic;
using UnityEngine;

public static class OccuredAnomaliesContainer
{
    private static List<OccuredAnomalyData> occuredAnomalyDatas = new List<OccuredAnomalyData>();

    public static void AddOccuredAnomalyData(OccuredAnomalyData occuredAnomalyData)
    {
        occuredAnomalyDatas.Add(occuredAnomalyData);

        Debug.Log($"В список добавилась произошедшая аномалия {occuredAnomalyData.AnomalyObject.name}");
    }

    public static void RemoveOccuredAnomalyByData(OccuredAnomalyData occuredAnomalyData)
    {
        occuredAnomalyDatas.Remove(GetOccuredAnomalyDataByData(occuredAnomalyData));
    }

    public static OccuredAnomalyData GetOccuredAnomalyDataByData(OccuredAnomalyData occuredAnomalyData)
    {
        foreach (var occuredAnomData in occuredAnomalyDatas)
        {
            // Нужно внимательно следить за тем, чтобы имена объектов на сцене были разные,
            // чтобы из списка выбирался конкретный аномальный объект.
            // Но нельзя сравнивать аномальные объекты по их типу (через GetType()) - это бессмысленно,
            // потому что у всех аномальных объектов один тип - AnomalyObject.
            if (occuredAnomData.AnomalyObject.GetLocalizationKey() == occuredAnomalyData.AnomalyObject.GetLocalizationKey()
            && occuredAnomData.Anomaly.GetType() == occuredAnomalyData.Anomaly.GetType())
            {
                return occuredAnomData;
            }

            Debug.Log($"Сравнение ключей локализации {occuredAnomData.AnomalyObject.GetLocalizationKey()} и {occuredAnomalyData.AnomalyObject.GetLocalizationKey()}");
            Debug.Log($"Сравнение типов аномалий {occuredAnomData.Anomaly.GetType().Name} и {occuredAnomalyData.Anomaly.GetType().Name}");
        }

        Debug.Log("Неправильная проверка данных или такая аномалия ещё не произошла. Возврат null.");
        return null;
    }
}