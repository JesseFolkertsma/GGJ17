Shader "Custom/CellShader" {
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_RampTex("Ramp Texture", 2D) = "white" {}
		_Normal ("Normal", 2D) = "bump" {}
		//_Slide("Lekker Sliden", Range(0.1, 1)) = 0.5
		//_Slide2("Lekker Sliden2", Range(0.1, 1)) = 0.5
	}
	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Toon lighting model
		#pragma surface surf Toon

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _RampTex;
		sampler2D _Normal;
		fixed4 _Color;

		//float _Slide;
		//float _Slide2;

		struct Input 
		{
			float2 uv_MainTex;
		};

		fixed4 LightingToon(SurfaceOutput s, fixed3 lightDir, fixed atten) {
			half NdotL = dot(s.Normal, lightDir);
			NdotL = tex2D(_RampTex, fixed2(NdotL, 0.5));

			fixed4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * NdotL * atten;
			c.a = s.Alpha;

			return c;
		}

		half4 LightingMyLambert(SurfaceOutput s, half3 lightDir, half atten) {

			half NdotL = saturate(dot(s.Normal, lightDir));

			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten);
			c.a = s.Alpha;
			return c;
		}

		half4 LightingMyHalfLambert(SurfaceOutput s, half3 lightDir, half atten) {

			half NdotL = saturate(dot(s.Normal, lightDir));

			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten);
			c.a = s.Alpha;
			return c;
		}

		half _Glossiness;
		half _Metallic;

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Normal = normalize(UnpackNormal(tex2D(_Normal, IN.uv_MainTex)));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
