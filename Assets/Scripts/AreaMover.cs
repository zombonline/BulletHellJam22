using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMover : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float boundaryX, boundaryY;
    [SerializeField] float scaleMin, scaleMax;
    public Vector2 targetPosition;
    public float targetScaleX, targetScaleY;
    bool isMoving = true;

    [SerializeField] float minTime, maxTime;

    private void Start()
    {
        StartCoroutine(RandomPositionAndScale());
    }

    private void Update()
    {
        if (LevelTimer.levelRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(targetScaleX, targetScaleY, 0), Time.deltaTime * speed);
        }

    }
    IEnumerator RandomPositionAndScale()
    {
        while (isMoving)
        {
            targetScaleX = Random.Range(scaleMin, scaleMax);
            targetScaleY = Random.Range(scaleMin, scaleMax);
            targetPosition = new Vector2(Random.Range(-boundaryX, boundaryX) / (1 + (0.06f * targetScaleX)), Random.Range(-boundaryY, boundaryY) / (1 + (0.06f * targetScaleY)));
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}
