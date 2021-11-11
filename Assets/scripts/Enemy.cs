using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private FieldOfView field_of_view;
    [SerializeField] private List<PatrolPoint> patrol_points;
    [SerializeField] private float speed = 1f;

    private int current_patrol_point = 0;
    private bool is_idle = false;
    private SpriteRenderer sprite;

    [System.Serializable]
    public struct PatrolPoint
    {
        public float x_destination;
        public float idle_time_after_arrival;
        public FacingDirection idle_facing_direction;
    }

    public enum FacingDirection
    {
        left = -1,
        right = 1
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (patrol_points.Count == 0)
        {
            PatrolPoint currentPoint = new PatrolPoint();
            currentPoint.x_destination = transform.position.x;
            currentPoint.idle_facing_direction = FacingDirection.right;

            patrol_points.Add(currentPoint);
        }

        Vector2 direction = new Vector2((float)patrol_points[current_patrol_point].idle_facing_direction, 0);
        FaceDirection(direction);
    }

    // Update is called once per frame
    void Update()
    {
        field_of_view.SetOrigin(transform.position);

        Patrol();
    }

    private void Patrol()
    {
        if (!is_idle)
        {
            Move(speed * Time.deltaTime);

            if (transform.position.x - patrol_points[current_patrol_point].x_destination == 0)
            {
                is_idle = true;
                StartCoroutine(WaitForNextPoint());
            }

        }
    }

    private void FaceDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            sprite.flipX = false;
            field_of_view.SetAimDirecion(Vector2.right);
        }
        else
        {
            sprite.flipX = true;
            field_of_view.SetAimDirecion(Vector2.left);
        }
    }

    private void Move(float distance)
    {
        Vector2 destination_point = new Vector2(patrol_points[current_patrol_point].x_destination, transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, destination_point, distance);

        Vector2 direction = new Vector2(patrol_points[current_patrol_point].x_destination - transform.position.x, 0);
        FaceDirection(direction);
    }

    private IEnumerator WaitForNextPoint()
    {
        Vector2 direction = new Vector2((float)patrol_points[current_patrol_point].idle_facing_direction, 0);
        FaceDirection(direction);
        yield return new WaitForSeconds(patrol_points[current_patrol_point].idle_time_after_arrival);

        NextPatrolPoint();
        is_idle = false;
    }

    private void NextPatrolPoint()
    {
        current_patrol_point = (current_patrol_point + 1) % patrol_points.Count;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Object"))
        {
            NextPatrolPoint();
        }
    }
}
