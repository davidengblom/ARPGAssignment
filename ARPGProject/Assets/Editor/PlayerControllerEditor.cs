using Player.Scripts;
using Resources.Scripts;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // DrawDefaultInspector();
        // var controller = (PlayerController) target;
        // var startPos = new Vector3(0, 1, 0);
        //
        // EditorGUILayout.LabelField("Current State", controller.movement.currentState);
        //
        // if (GUILayout.Button("Set New Reset Position"))
        // {
        //     startPos = controller.transform.position;
        // }
        //
        // if (GUILayout.Button("Reset Position"))
        // {
        //     controller.transform.position = startPos;
        //     controller.movement.agent.destination = startPos;
        // }
        //
        // if (GUILayout.Button("Reset Default Values"))
        // {
        //     startPos = new Vector3(0, 1, 0);
        // }
    }
}
