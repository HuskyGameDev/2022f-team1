Shader "Hidden/Pallette"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
        _Pallette ("Pallette", 2D) = "white" {}
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader
    {

        Tags
		{ 
			"Queue"="Transparent" 
			"RenderType"="Transparent" 
		}

        Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
                float4 vertex : SV_POSITION;
            };
            
            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _Pallette;
            sampler2D _AlphaTex;

			float _AlphaSplitEnabled;

            /*fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D(_MainTex, uv);
                fixed4 col = tex2D(_Pallette, float2((color.r), (color.g)));
                float4 result;
                result.rgb = tex2D(_MainTex, col).rgb;
                result.a = tex2D(_MainTex, col).a;s

                #if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
				    if (_AlphaSplitEnabled)
					color.a = tex2D (_AlphaTex, uv).r;
                #endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

				return result;
			}*/

            fixed4 frag (v2f i) : SV_Target
            {
                //Will swap the color based on the pallete's UV coodrdinates
                float4 rgba = tex2D(_MainTex, 1-i.uv);
                /*float4 final_color = tex2D(_Pallette, float2((rgba.r), 1-(rgba.g)));
                
                if (rgba.r >= 0){                
                    final_color.a = 1;
                } else {
                    final_color.a = 0;
                }

                return final_color;*/
                return rgba;
            }

            ENDCG
        }
    }
}
