using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTransistion : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    Cinemachine.CinemachineConfiner confiner;

    enum Direction { Up, Down, Left, Right }
    [SerializeField] Direction direction;
    private void Awake()
    {
        confiner = FindObjectOfType<Cinemachine.CinemachineConfiner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            confiner.m_BoundingShape2D = mapBoundary;
            confiner.InvalidatePathCache();

            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {

        Vector3 pos = player.transform.position;
        switch (direction)
        {
            case Direction.Up:
                pos.y += 2;
                break;
            case Direction.Down:
                pos.y -= 2;
                break;
            case Direction.Left:
                pos.x -= 2;
                break;
            case Direction.Right:
                pos.x += 2;
                break;
        }
        player.transform.position = pos;
    }
}   


