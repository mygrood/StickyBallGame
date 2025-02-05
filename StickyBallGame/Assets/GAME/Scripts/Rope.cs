using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Rope:MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    public void Attach(Vector3 startPoint, Vector3 endPoint)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
    
    public void Detach()
    {
        lineRenderer.enabled = false;
    }

    public void UpdateRope(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
