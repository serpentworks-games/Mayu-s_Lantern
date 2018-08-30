Shader "Toon/Lit Outline3" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (.002, 0.03)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 
		_BumpAmt("Distortion", range(0,128)) = 10
			
		_BumpMap("Normalmap", 2D) = "bump" {}
		_RimColor("Rim Color", Color) = (0.26,0.19,0.16,0.0)
			_RimPower("Rim Power", Range(0.5,8.0)) = 3.0
	}

	SubShader {
		Tags { "RenderType"= "Transparent" }
		UsePass "Toon/Lit Rim/FORWARD"
		//UsePass "Toon/Basic Outline/OUTLINE"
		UsePass "FX/Glass/Stained BumpDistort"
	} 
	
	Fallback "Toon/Lit"
}
