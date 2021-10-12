using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(WaypointNav wayPoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow * 0.5f;
        }

        Gizmos.DrawSphere(wayPoint.transform.position, .1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(wayPoint.transform.position + (wayPoint.transform.right * wayPoint.width / 2f),
            wayPoint.transform.position - (wayPoint.transform.right * wayPoint.width / 2f));

        // if (wayPoint.previousWaypoint != null)
        {
            //     Gizmos.color = Color.red;
            //     Vector3 offset = wayPoint.transform.right * wayPoint.width / 2f;
            //     Vector3 offsetTo = wayPoint.previousWaypoint.transform.right * wayPoint.previousWaypoint.width / 2f;

            //     Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.previousWaypoint.transform.position + offsetTo);
            // }
            //        if (wayPoint.wayPoints != null)
            //        {
            //            Gizmos.color = Color.green;
            //            Vector3 offset = wayPoint.transform.right * -wayPoint.width / 2f;
            //            Vector3 offsetTo = wa.right * -wayPoint.nextwayPoint.width / 2f;

            //            Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.nextwayPoint.transform.position + offsetTo);
            //        }
            //    }
            //}
        }
    }
}
