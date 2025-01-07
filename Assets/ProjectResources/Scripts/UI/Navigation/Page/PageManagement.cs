using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PageManagement : MonoBehaviour
{
    private static event Action onPagesFinded;

    [SerializeField] private List<GameObject> pages;
    private static List<GameObject> staticPages;

    private void Awake()
    {
        SetStaticPages();
    }

    private void OnValidate()
    {
        SetStaticPages();
    }

    private void OnEnable()
    {
        onPagesFinded += SetSerializePages;
    }
    private void OnDisable()
    {
        onPagesFinded -= SetSerializePages;
    }

    private static List<GameObject> getAllPagesFromScene()
    {
        GameObject[] allGameObjectsOnScene;
        allGameObjectsOnScene = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        List<GameObject> pages = new List<GameObject>();

        foreach (GameObject obj in allGameObjectsOnScene)
        {
            if (obj.name.Contains("_Page"))
            {
                pages.Add(obj);
            }
        }

        return pages;
    }

    private void SetSerializePages()
    {
        pages = staticPages;
    }
    private void SetStaticPages()
    {
        staticPages = pages;
    }

    public static void FindPages()
    {
        staticPages = getAllPagesFromScene();

        onPagesFinded?.Invoke();
    }

    public static List<GameObject> GetPages()
    {
        return new List<GameObject>(staticPages);
    }

    public static void EnableByIndex(int index)
    {
        disableAllPages();

        staticPages[index].SetActive(true);
    }

    private static void disableAllPages()
    {
        foreach (var page in staticPages)
        {
            page.SetActive(false);
        }
    }
}