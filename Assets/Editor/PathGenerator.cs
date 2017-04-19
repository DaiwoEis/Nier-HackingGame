using System;
using UnityEditor;
using UnityEngine;

public class PathGenerator : ScriptableWizard
{
    [SerializeField]
    private TextAsset _pathData = null;

    [MenuItem("Help/Path")]
    public static void GeneratePath()
    {
        DisplayWizard<PathGenerator>("Create a path", "Create", "Apply");
    }

    private void OnWizardCreate()
    {
        GameObject pathGO = new GameObject("Path");
        pathGO.transform.position = Vector3.zero;
        GeneratePath(pathGO);   
    }

    private void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            Transform path = Selection.activeTransform;
            path.gameObject.name = "Path";

            foreach (var child in path.GetComponentsInChildren<Transform>(true))
            {
                if (child == path) continue;
                DestroyImmediate(child.gameObject);
            }

            GeneratePath(path.gameObject);
        }
    }

    private void GeneratePath(GameObject pathGO)
    {
        string[] datas = _pathData.text.Split(new[] { ';', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        string pointName = "WayPoint ";
        int number = 0;
        for (int i = 3; i < datas.Length - 3; i += 3)
        {
            number++;
            Vector3 wayPointPos = new Vector3(float.Parse(datas[i + 1]), 0f, float.Parse(datas[i + 2]));
            GameObject wayPoint = new GameObject(pointName + number);
            IconManager.SetIcon(wayPoint, IconManager.LabelIcon.Yellow);
            wayPoint.transform.SetParent(pathGO.transform);
            wayPoint.transform.SetAsLastSibling();
            wayPoint.transform.localPosition = wayPointPos;
        }
    }
}
