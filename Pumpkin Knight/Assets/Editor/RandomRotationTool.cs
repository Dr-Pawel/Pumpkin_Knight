using UnityEngine;
using UnityEditor;

public class RandomRotationTool : EditorWindow
{
    [MenuItem("Tools/Random Rotation Tool")]
    public static void ShowWindow()
    {
        GetWindow<RandomRotationTool>("Random Rotation");
    }

    private float minY = 0f;
    private float maxY = 360f;

    private void OnGUI()
    {
        GUILayout.Label("random rotation selected object", EditorStyles.boldLabel);

        minY = EditorGUILayout.FloatField("min angle Y", minY);
        maxY = EditorGUILayout.FloatField("max angle Y", maxY);

        if (GUILayout.Button("Rotate selected randmly"))
        {
            RandomizeSelected();
        }
    }

    private void RandomizeSelected()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Randomize Rotation");
            Vector3 currentRotation = obj.transform.eulerAngles;
            float randomY = Random.Range(minY, maxY);
            obj.transform.rotation = Quaternion.Euler(currentRotation.x, randomY, 0);
        }
        Debug.Log($"rotated {Selection.gameObjects.Length} objects.");
    }
}
