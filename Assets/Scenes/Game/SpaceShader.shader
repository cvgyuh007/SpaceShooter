Shader "Custom/Space" {
	Properties {
		_Color1 ("Inside Color", Color) = (1,1,1,1)
		_Color2 ("Outside Color", Color) = (1,1,1,1)
		_Range ("Range",Float) = 100.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		Lighting Off

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf NoLight

		float4 LightingNoLight (SurfaceOutput s, float3 lightDir,half3 viewDir, half atten)
		{
			float4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input 
		{
			float3 worldPos;
		};

		fixed4 _Color1;
		fixed4 _Color2;
		float _Range;

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			float x = IN.worldPos.x;
			float y = IN.worldPos.y;

			fixed4 color;
			if (x * x + y * y <= _Range * _Range)
			{
				color = _Color1;
			}
			else
			{
				color = _Color2;
			}
			o.Albedo = color.rgb;
		}
		ENDCG
	}
}
