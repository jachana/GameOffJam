using UnityEngine;

public class PivotSeeSaw : SeeSaw
{
    [SerializeField]
    float glitch_offset;
    protected override void EndGlitch()
    {
        Vector3 offset = CalculateOffset();

        _sprite_renderer.color = Color.white;
        _pivot.transform.position -= offset;
    }

    protected override SpriteRenderer GetSpriteRenderer()
    {
        return _pivot.GetComponent<SpriteRenderer>();
    }

    protected override void StartGlitch()
    {
        Vector3 offset = CalculateOffset();
        _sprite_renderer.color = Color.red;
        _pivot.transform.position += offset;
    }

    private Vector3 CalculateOffset()
    {
        float offset_x = glitch_offset * _platform.localScale.x * Mathf.Cos(_platform.localRotation.eulerAngles.z * Mathf.Deg2Rad);
        float offset_y = glitch_offset * _platform.localScale.x * Mathf.Sin(_platform.localRotation.eulerAngles.z * Mathf.Deg2Rad);
        float offset_z = 0;
        return new Vector3(offset_x, offset_y, offset_z);
    }
}
