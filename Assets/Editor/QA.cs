using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(OpeningManager))]
public class QA : Editor
{


   public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        OpeningManager openingManager = (OpeningManager)target;

        
        EditorGUILayout.HelpBox("this is aditor functions", MessageType.Info);
       

        if (GUILayout.Button("next scene onContinue()"))
        {
            openingManager.onContinue();
        }
    }
}
