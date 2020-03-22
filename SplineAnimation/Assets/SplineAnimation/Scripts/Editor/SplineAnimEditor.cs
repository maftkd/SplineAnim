using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimateAlongSpline))]
public class SplineAnimEditor : Editor
{

    void OnEnable()
    {
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AnimateAlongSpline animator = (AnimateAlongSpline)target;
        if (GUILayout.Button("Foobar"))
        {
            animator.FooBob();
        }
    }

   
}
