﻿Shader "Unlit/UnlitTransparentAlpha" 
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)	
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white"
	}

	Category 
	{
		Lighting Off
		//ZWrite Off
        
		Cull back
		Blend SrcAlpha OneMinusSrcAlpha
        AlphaTest Greater 0.001  // uncomment if you have problems like the sprites or 3d text have white quads instead of alpha pixels.
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Opaque"}

		SubShader 
		{

           		Pass 
           		{
           			ZWrite On  // uncomment if you have problems like the sprite disappear in some rotations.
    				SetTexture [_MainTex] 
            			{
					ConstantColor [_Color]
               				Combine Texture * constant
				}

			}
		}
	}
}