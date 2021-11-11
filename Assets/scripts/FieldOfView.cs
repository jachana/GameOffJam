using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private Mesh mesh;
    private Vector3 origin;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private int ray_count = 20;
    [SerializeField] private float startingAngle = 0f;
    [SerializeField] private float fov_degrees = 45f;
    [SerializeField] private float view_distance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = startingAngle;
        float angle_increase = fov_degrees / ray_count;

        Vector3[] vertices = new Vector3[ray_count + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[ray_count * 3];


        vertices[0] = origin;

        int vertex_index = 1;
        int triangle_index = 0;
        for (int i = 0; i <= ray_count; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycast_hit = Physics2D.Raycast(origin, GetVector3FromAngle(angle), view_distance, layerMask);

            if (raycast_hit.collider == null)
            {
                vertex = origin + GetVector3FromAngle(angle) * view_distance;
            }
            else
            {
                vertex = raycast_hit.point;
            }
            vertices[vertex_index] = vertex;

            if (i > 0)
            {
                triangles[triangle_index] = 0;
                triangles[triangle_index + 1] = vertex_index - 1;
                triangles[triangle_index + 2] = vertex_index;

                triangle_index += 3;
            }

            vertex_index++;
            angle -= angle_increase;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirecion(Vector3 aim_direction)
    {
        startingAngle = GetAngleFromVector3(aim_direction) + fov_degrees / 2f;
    }

    private Vector3 GetVector3FromAngle(float angle)
    {
        float angle_rad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angle_rad), Mathf.Sin(angle_rad));
    }

    private float GetAngleFromVector3(Vector3 direction)
    {
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0)
            angle += 360;

        return angle;
    }
}
