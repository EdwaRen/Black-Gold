using UnityEngine;
using System.Collections;

public class _Main : MonoBehaviour {
	//This is some unused code that for a fadeout effect. It was replaced by 3-4 lines in another script
	public void Scene_Update(string name){
		AutoFade.LoadLevel(name , 0.1f);
	}
}

public class AutoFade : MonoBehaviour
{
	private static AutoFade m_Instance = null;
	private Material m_Material = null;
	private string m_LevelName = "";
	private int m_LevelIndex = 0;
	private bool m_Fading = false;

	private static AutoFade Instance
	{
		get
		{
			if (m_Instance == null)
			{
				m_Instance = (new GameObject("AutoFade")).AddComponent<AutoFade>();
			}
			return m_Instance;
		}
	}
	public static bool Fading
	{
		get { return Instance.m_Fading; }
	}

	private void Awake()
	{
		DontDestroyOnLoad(this);
		m_Instance = this;
		m_Material = new Material("Shader \"Plane/No zTest\" { SubShader { Pass { Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off Fog { Mode Off } BindChannels { Bind \"Color\",color } } } }");
	}

	private void DrawQuad(Texture2D aTexture,float aAlpha)
	{
		Color aColor = Color.white;
		Color oColor = GUI.color;
		aColor.a = aAlpha;

		m_Material.SetPass(0);
		GL.PushMatrix();
		GL.LoadPixelMatrix(0,Screen.width,Screen.height,0);
		GUI.color = aColor;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), aTexture);
		GUI.color = oColor;
		GL.PopMatrix();
	}

	private IEnumerator Fade(float aFadeTime)
	{
		Texture2D m_Texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
		yield return new WaitForEndOfFrame();
		m_Texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
		m_Texture.Apply ();

		float t = 0.1f;
		if (m_LevelName != "")
			Application.LoadLevel(m_LevelName);
		else
			Application.LoadLevel(m_LevelIndex);
		while (t>0.0f)
		{
			yield return new WaitForEndOfFrame();
			t = Mathf.Clamp01(t - Time.deltaTime / aFadeTime);
			DrawQuad(m_Texture,t);
		}
		m_Fading = false;
	}
	private void StartFade(float aFadeTime)
	{
		m_Fading = true;
		StartCoroutine(Fade(aFadeTime));
	}

	public static void LoadLevel(string aLevelName,float aFadeTime)
	{
		if (Fading) return;
		Instance.m_LevelName = aLevelName;
		Instance.StartFade(aFadeTime);
	}
	public static void LoadLevel(int aLevelIndex,float aFadeTime)
	{
		if (Fading) return;
		Instance.m_LevelName = "";
		Instance.m_LevelIndex = aLevelIndex;
		Instance.StartFade(aFadeTime);
	}
}