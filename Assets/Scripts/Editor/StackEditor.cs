using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StackEditor : EditorWindow
{
    float zValue;
    float yRotationValue;
    int count;
    GameObject parent;

    [MenuItem("Window/Stack")]
    public static void ShowWindow()
    {
        GetWindow<StackEditor>("StackEditor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create From Selected Object", EditorStyles.boldLabel);

        GUILayout.Label("Z Value", EditorStyles.boldLabel);
        zValue = EditorGUILayout.FloatField(zValue);

        GUILayout.Label("Y Rotation Value", EditorStyles.boldLabel);
        yRotationValue = EditorGUILayout.FloatField(yRotationValue);

        GUILayout.Label("Count", EditorStyles.boldLabel);
        count = EditorGUILayout.IntField(count);

        parent = GameObject.FindGameObjectWithTag("Parent");

        if (GUILayout.Button("Create"))
        {
            foreach (GameObject gameObject in Selection.gameObjects)
            {
                for (int i = 1; i <= count; i++)
                {
                    GameObject obj = Instantiate(gameObject);
                    Vector3 pos = gameObject.transform.position;
                    Quaternion rotation = gameObject.transform.rotation;

                    rotation.y = yRotationValue;

                    if(rotation.y == -90 || rotation.y == 90)
                    {
                        if(yRotationValue < 0)
                        {
                            pos.x -= zValue * i;
                        }
                        else
                        {
                            pos.x += zValue * i;
                        }
                    }
                    else if (rotation.y == 180)
                    {
                        pos.z -= zValue * i;
                    }
                    else
                    {
                        pos.z += zValue * i;
                    }

                    
                    obj.transform.position = pos;
                    obj.transform.SetParent(parent.transform);
                }
            }
        }
    }
}
