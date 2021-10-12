using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaypointManagerWindow : EditorWindow
{
    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<WaypointManagerWindow>();
    }
    public Transform waypointRoot;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));

        if (waypointRoot == null)
        {
            EditorGUILayout.HelpBox("Root transform must be selected. please assign a root transform.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }


        obj.ApplyModifiedProperties();
    }

    void DrawButtons()
    {
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            if (GUILayout.Button("Create Waypoint Before"))
            {
                CreateWaypointBefore();
            }
            if (GUILayout.Button("Create Waypoint After"))
            {
                CreateWaypointAfter();
            }
            if (GUILayout.Button("Remove Waypoint"))
            {
                RemoveWaypoint();
            }
        }
    }

    void CreateWaypoint()
    {

        GameObject waypointObject = new GameObject("Waypoint" + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        Waypoint wayPoint = waypointObject.GetComponent<Waypoint>();
        if (waypointRoot.childCount > 1)
        {
            wayPoint.previousWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<Waypoint>();
            wayPoint.previousWaypoint.nextWaypoint = wayPoint;
            //Place the Waypoint at the last postion
            wayPoint.transform.position = wayPoint.previousWaypoint.transform.position;
            wayPoint.transform.forward = wayPoint.previousWaypoint.transform.forward;
        }


        Selection.activeGameObject = wayPoint.gameObject;
    }

    void CreateWaypointBefore()
    {
        GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        Waypoint newwaypoint = waypointObject.GetComponent<Waypoint>();

        Waypoint selectedwaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointObject.transform.position = selectedwaypoint.transform.position;
        waypointObject.transform.forward = selectedwaypoint.transform.forward;

        if (selectedwaypoint.previousWaypoint != null)
        {
            newwaypoint.previousWaypoint = selectedwaypoint.previousWaypoint;
            selectedwaypoint.previousWaypoint.nextWaypoint = newwaypoint;
        }

        newwaypoint.nextWaypoint = selectedwaypoint;

        selectedwaypoint.previousWaypoint = newwaypoint;

        newwaypoint.transform.SetSiblingIndex(selectedwaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newwaypoint.gameObject;
    }
    void CreateWaypointAfter()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        Waypoint newwaypoint = waypointObject.GetComponent<Waypoint>();

        Waypoint selectedwaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointObject.transform.position = selectedwaypoint.transform.position;
        waypointObject.transform.forward = selectedwaypoint.transform.forward;

        newwaypoint.previousWaypoint = selectedwaypoint;

        if (selectedwaypoint.nextWaypoint != null)
        {
            selectedwaypoint.nextWaypoint.previousWaypoint = newwaypoint;
            newwaypoint.nextWaypoint = selectedwaypoint.nextWaypoint;
        }

        selectedwaypoint.nextWaypoint = newwaypoint;

        newwaypoint.transform.SetSiblingIndex(selectedwaypoint.transform.GetSiblingIndex());

        Selection.activeGameObject = newwaypoint.gameObject;
    }
    void RemoveWaypoint()
    {
        Waypoint selectedwaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        if (selectedwaypoint.nextWaypoint != null)
        {
            selectedwaypoint.nextWaypoint.previousWaypoint = selectedwaypoint.previousWaypoint;
        }
        if (selectedwaypoint.previousWaypoint != null)
        {
            selectedwaypoint.previousWaypoint.nextWaypoint = selectedwaypoint.nextWaypoint;
            Selection.activeGameObject = selectedwaypoint.previousWaypoint.gameObject;
        }
        DestroyImmediate(selectedwaypoint.gameObject);
    }
}
