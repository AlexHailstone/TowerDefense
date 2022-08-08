using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

	public Image image;
	public AnimationCurve curve;



	// need 2 functions: 1 fade in , 1 fade out

	private void Start()
	{
		StartCoroutine(FadeIn());
	}


	IEnumerator FadeIn()
	{
		//alpha from 1 to 0
		float t = 1f;


		while (t > 0f)
		{
			t -= Time.deltaTime;
			float a = curve.Evaluate(t);
			image.color = new Color(0f, 0f, 0f, a);
			//this tells the CoRoutine to wait 1 frame before starting over...
			//we're emulating the Update() function
			yield return 0;
		}

	}

	public void FadeTo(string scene)
	{
		StartCoroutine(FadeOut(scene));
	}


	IEnumerator FadeOut(string scene)
	{
		//alpha from 1 to 0
		float t = 0f;


		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = curve.Evaluate(t);
			image.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}

		SceneManager.LoadScene(scene);

	}
}
