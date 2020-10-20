using Resources.Scripts;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var controller = (PlayerController) target;
        var startPos = new Vector3(0, 1, 0);
        
        EditorGUILayout.LabelField("Current State", controller.movement.currentState);
        
        if (GUILayout.Button("Reset Position"))
        {
            controller.transform.position = startPos;
            controller.movement.agent.destination = startPos;
        }
    }
}
