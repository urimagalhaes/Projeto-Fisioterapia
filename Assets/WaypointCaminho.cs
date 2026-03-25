using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCaminho : MonoBehaviour
{
    [Header("Waypoints")]
    public Transform[] waypoints;

    // Retorna o waypoint pelo índice
    public Transform GetWaypoint(int index)
    {
        return waypoints[index];
    }

    public int GetNextIndex(int currentIndex)
    {
        int nextIndex = currentIndex + 1;
        if (nextIndex >= waypoints.Length)
            nextIndex = 0; // loop no caminho
        return nextIndex;
    }

    // Desenha o caminho no editor (Gizmos)
    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        Gizmos.color = Color.yellow;

        for (int i = 0; i < waypoints.Length; i++)
        {
            int nextIndex = (i + 1) % waypoints.Length;

            if (waypoints[i] != null && waypoints[nextIndex] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[nextIndex].position);
                Gizmos.DrawSphere(waypoints[i].position, 0.3f);
            }
        }
    }
}
