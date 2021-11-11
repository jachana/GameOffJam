using UnityEngine;

public class PivotSeeSaw : MonoBehaviour, IGlitchable
{
    [SerializeField]
    float glitch_offset;
    [SerializeField]
    Transform pivot, platform;
    [SerializeField]
    bool is_glitching = false;
    SpriteRenderer sprite;
    public void ToggleGlitch()
    {
        is_glitching = !is_glitching;
        float offset_x = glitch_offset * platform.localScale.x / 2 * Mathf.Cos(platform.localRotation.eulerAngles.z * Mathf.Deg2Rad);
        float offset_y = glitch_offset * platform.localScale.x / 2 * Mathf.Sin(platform.localRotation.eulerAngles.z * Mathf.Deg2Rad);
        float offset_z = 0;

        Vector3 offset = new Vector3(offset_x, offset_y, offset_z);

        if (is_glitching)
        {
            sprite.color = Color.red;
            pivot.transform.position += offset;
        }
        else
        {
            sprite.color = Color.white;

            pivot.transform.position -= offset;
        }


    }

    void Start()
    {
        GlitchManager.Instance.AddGlitchableToList(this);
        sprite = pivot.GetComponent<SpriteRenderer>();
    }
}
