using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private BackgroundSegment[] segments; 
    [SerializeField] private Transform player;
    
    private float segmentHeight;

    private void Start()
    {
        segmentHeight = segments[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        foreach (var segment in segments)
        {
            if (segment.transform.position.y + segmentHeight / 2 < player.position.y - segmentHeight)
            {
                MoveSegmentUp(segment);
            }
        }
    }

    private void MoveSegmentUp(BackgroundSegment segment)
    {
        float newY = GetHighestSegment().transform.position.y + segmentHeight;
        segment.transform.position = new Vector3(0, newY, 0);
        segment.RespawnObjects();
    }

    private BackgroundSegment GetHighestSegment()
    {
        BackgroundSegment highest = segments[0];
        foreach (var segment in segments)
        {
            if (segment.transform.position.y > highest.transform.position.y)
                highest = segment;
        }
        return highest;
    }
}