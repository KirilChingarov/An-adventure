using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
	public int targetFrameRate = 60;
	float dt = 0f;

	void Start()
	{
		QualitySettings.vSyncCount = 0;
	}


	void Update()
	{
		if (Application.targetFrameRate != targetFrameRate)
		{
			Application.targetFrameRate = targetFrameRate;
		}
		dt += (Time.unscaledDeltaTime - dt);
	}
}
