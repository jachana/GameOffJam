/**
This work is licensed under a Creative Commons Attribution 3.0 Unported License.
http://creativecommons.org/licenses/by/3.0/deed.en_GB

You are free:

to copy, distribute, display, and perform the work
to make derivative works
to make commercial use of the work
*/

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/GlitchEffect")]
[RequireComponent(typeof(Camera))]
public class GlitchEffect : MonoBehaviour, IGlitchable
{
	public Texture2D displacementMap;
	public Shader Shader;
	[Header("Glitch Intensity")]

	[Range(0, 1)]
	public float intensity;

	[Range(0, 1)]
	public float flipIntensity;

	[Range(0, 1)]
	public float colorIntensity;

	private float _glitchup;
	private float _glitchdown;
	private float flicker;
	private float _glitchupTime = 0.05f;
	private float _glitchdownTime = 0.05f;
	private float _flickerTime = 0.5f;
	private Material _material;
	private bool _is_glitching = true;

	void Start()
	{
		_material = new Material(Shader);
		GlitchManager.Instance.AddGlitchableToList(this);

	}

	// Called by camera to apply image effect
	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		float used_flip_intensity;
		float used_color_intensity;
		float used_intensity;

		if (!_is_glitching)
		{ 
			 used_flip_intensity = flipIntensity;
			 used_color_intensity = colorIntensity;
			 used_intensity = intensity;
		}
		else
		{
			 used_flip_intensity = 0;
			 used_color_intensity =0;
			 used_intensity = 0;

		}

		_material.SetFloat("_Intensity", used_intensity);
		_material.SetFloat("_ColorIntensity", colorIntensity);
		_material.SetTexture("_DispTex", displacementMap);

		flicker += Time.deltaTime * used_color_intensity;
		if (flicker > _flickerTime)
		{
			_material.SetFloat("filterRadius", Random.Range(-3f, 3f) * used_color_intensity);
			_material.SetVector("direction", Quaternion.AngleAxis(Random.Range(0, 360) * used_color_intensity, Vector3.forward) * Vector4.one);
			flicker = 0;
			_flickerTime = Random.value;
		}

		if (used_color_intensity == 0)
			_material.SetFloat("filterRadius", 0);

		_glitchup += Time.deltaTime * used_flip_intensity;
		if (_glitchup > _glitchupTime)
		{
			if (Random.value < 0.1f * used_flip_intensity)
				_material.SetFloat("flip_up", Random.Range(0, 1f) * used_flip_intensity);
			else
				_material.SetFloat("flip_up", 0);

			_glitchup = 0;
			_glitchupTime = Random.value / 10f;
		}

		if (used_flip_intensity == 0)
			_material.SetFloat("flip_up", 0);

		_glitchdown += Time.deltaTime * used_flip_intensity;
		if (_glitchdown > _glitchdownTime)
		{
			if (Random.value < 0.1f * used_flip_intensity)
				_material.SetFloat("flip_down", 1 - Random.Range(0, 1f) * used_flip_intensity);
			else
				_material.SetFloat("flip_down", 1);

			_glitchdown = 0;
			_glitchdownTime = Random.value / 10f;
		}

		if (used_flip_intensity == 0)
			_material.SetFloat("flip_down", 1);

		if (Random.value < 0.05 * used_intensity)
		{
			_material.SetFloat("displace", Random.value * used_intensity);
			_material.SetFloat("scale", 1 - Random.value * used_intensity);
		}
		else
			_material.SetFloat("displace", 0);

		Graphics.Blit(source, destination, _material);

	}

    public void ToggleGlitch()
    {
		_is_glitching = !_is_glitching;

	}
}
