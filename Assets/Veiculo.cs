using UnityEngine;

public class VehicleWaypointFollower : MonoBehaviour
{
    [Header("Referências")]
    public WaypointCaminho waypointPath;

    [Header("Configurações de Movimento")]
    public float moveSpeed = 10f;
    public float rotationSpeed = 5f;
    public float waypointThreshold = 1.5f;

    [Header("Inércia")]
    public float acceleration = 5f;   // quão rápido acelera
    public float deceleration = 3f;   // quão rápido desacelera

    private int currentWaypointIndex = 0;
    private bool isFollowingPath = false;
    private float currentSpeed = 0f;  // velocidade atual (começa em 0)

    private void Update()
    {
        bool aPressed = Input.GetKey(KeyCode.A);
        bool dPressed = Input.GetKey(KeyCode.D);

        if (aPressed && dPressed)
            isFollowingPath = true;

        if (!aPressed || !dPressed)
            isFollowingPath = false;

        // Acelera ou desacelera suavemente
        if (isFollowingPath)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Continua movendo enquanto ainda tem velocidade
        if (currentSpeed > 0f && waypointPath != null)
        {
            FollowPath();
        }
    }

    private void FollowPath()
    {
        Transform targetWaypoint = waypointPath.GetWaypoint(currentWaypointIndex);
        if (targetWaypoint == null) return;

        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // Usa currentSpeed em vez de moveSpeed fixo
        transform.position += direction * currentSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        if (distance <= waypointThreshold)
        {
            currentWaypointIndex = waypointPath.GetNextIndex(currentWaypointIndex);
        }
    }
}