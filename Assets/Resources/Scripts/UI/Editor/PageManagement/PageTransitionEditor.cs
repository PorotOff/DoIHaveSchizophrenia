#if UNITY_EDITOR
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(PageNavigationByButton))]
    public class PageTransitionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
    
            PageNavigationByButton pageTransitionByButton = (PageNavigationByButton)target;
            List<GameObject> pages = PageManagement.GetPages();
            string[] pageNames = pages.Select(page => page.name).ToArray();
    
            int currentPageIndex = pageTransitionByButton.GetIndex();
            int selectedPageIndex = EditorGUILayout.Popup("Page", currentPageIndex, pageNames);
    
            if (selectedPageIndex != currentPageIndex)
            {
                pageTransitionByButton.SetIndex(selectedPageIndex);
            }
        }
    }
#endif