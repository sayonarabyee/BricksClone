using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LaunchPreview))]
public class Launcher : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private BrickSpawner blickSpawner;
    private LaunchPreview launchPreview;



    private int ballsReady;
    private List<Ball> balls = new List<Ball>();

    [SerializeField] Ball ballPrefab;

    private void Awake()
    {
        blickSpawner = FindObjectOfType<BrickSpawner>();
        launchPreview = GetComponent<LaunchPreview>();
        CreateBalls();
        CreateBalls();
        CreateBalls();
    }
    public void ReturnBall()
    {
        ballsReady++;
        if (ballsReady == balls.Count)
        {
            blickSpawner.SpawnBlocks();
            CreateBalls();
        }
    }
    void CreateBalls()
    {
        var ball = Instantiate(ballPrefab);
        balls.Add(ball);
        ballsReady++;
    }
    private void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPos);
        }
        else if (Input.GetMouseButton(0))
        {
            CountinueDrag(worldPos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        StartCoroutine(LaunchBalls());
    }

    private IEnumerator LaunchBalls()
    {
        Vector3 direction = endPos - startPos;
        direction.Normalize();

        foreach (var ball in balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.1f);
        }
        ballsReady = 0;
    }

    private void CountinueDrag(Vector3 worldPos)
    {
        endPos = worldPos;

        Vector3 direction = endPos - startPos;

        launchPreview.SetEndPosition(transform.position - direction);
    }

    private void StartDrag(Vector3 worldPos)
    {
        startPos = worldPos;
        launchPreview.SetStartPoint(transform.position);
    }
}
