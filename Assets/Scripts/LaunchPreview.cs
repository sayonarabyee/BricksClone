using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class LaunchPreview : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 dragStartPos;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    public void SetStartPoint(Vector3 worldPoint)
    {
        dragStartPos = worldPoint;
        line.SetPosition(0, dragStartPos);
    }
    public void SetEndPosition(Vector3 worldPoint)
    {
        Vector3 pointOffset = worldPoint - dragStartPos;
        Vector3 endPoint = transform.position + pointOffset;

        line.SetPosition(1, endPoint);
    }
}
