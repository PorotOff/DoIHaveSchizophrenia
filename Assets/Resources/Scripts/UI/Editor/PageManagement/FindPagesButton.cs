#if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(PageManagement))]
    public class FindPagesButton : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
    
            if (GUILayout.Button("Найти все страницы на сцене"))
            {
                PageManagement.FindPages();
            }
        }
    }
#endif