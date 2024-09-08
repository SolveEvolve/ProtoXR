Shader "Custom/AdditiveBlendWithBlurShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Intensity ("Intensity", Range(0.0, 5.0)) = 1.0 // Variable for intensity control
        _Transparency ("Transparency", Range(0.0, 1.0)) = 1.0 // Variable for transparency control
        _Falloff ("Alpha Falloff", Range(0.0, 1.0)) = 1.0 // Variable for falloff strength
        _FalloffStart ("Falloff Start", Range(0.0, 1.0)) = 0.0 // Start of falloff (bottom now)
        _FalloffEnd ("Falloff End", Range(0.0, 1.0)) = 1.0 // End of falloff (top now)
        _ArchHeight ("Arch Height", Range(0.0, 2.0)) = 0.5 // Height of the arch
        _BlurAmount ("Blur Amount", Range(0.0, 10.0)) = 1.0 // Controls the strength of the blur effect
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            ZWrite Off
            Blend SrcAlpha One // Additive blending

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Intensity;
            float _Transparency;
            float _Falloff;
            float _FalloffStart;
            float _FalloffEnd;
            float _ArchHeight;
            float _BlurAmount;

            // Vertex shader to modify the arch shape of the object
            v2f vert (appdata v)
            {
                v2f o;

                // Create an arch shape by modifying the vertex's y-position based on x-position
                float x = v.vertex.x;
                float arch = pow(x, 2.0) * _ArchHeight; // Parabolic curve
                v.vertex.y += arch; // Apply arch deformation to the y-position

                o.vertex = UnityObjectToClipPos(v.vertex); // Transform to clip space
                o.uv = v.uv;
                return o;
            }

            // Function to simulate a blur effect by sampling neighboring pixels
            fixed4 blur(sampler2D tex, float2 uv, float amount)
            {
                float2 texelSize = amount * float2(1.0 / _ScreenParams.x, 1.0 / _ScreenParams.y); // Texel size based on blur amount
                fixed4 color = tex2D(tex, uv); // Sample the original pixel

                // Sample surrounding pixels for blur
                color += tex2D(tex, uv + texelSize * float2(-1.0, -1.0));
                color += tex2D(tex, uv + texelSize * float2(-1.0, 1.0));
                color += tex2D(tex, uv + texelSize * float2(1.0, -1.0));
                color += tex2D(tex, uv + texelSize * float2(1.0, 1.0));

                // Average the samples (including the original pixel)
                color /= 5.0;

                return color;
            }

            // Fragment shader to handle blur, falloff, intensity, and transparency
            fixed4 frag (v2f i) : SV_Target
            {
                // Apply blur to the texture
                fixed4 col = blur(_MainTex, i.uv, _BlurAmount);

                // Apply intensity
                col.rgb *= _Intensity;

                // Calculate falloff for alpha based on UV.y, with user-defined start/end
                float falloffRange = saturate((i.uv.y - _FalloffStart) / (_FalloffEnd - _FalloffStart));
                float falloffAlpha = lerp(0.0, 1.0, falloffRange); // Flip falloff direction
                falloffAlpha *= _Falloff;

                // Apply transparency and falloff to the alpha channel
                col.a *= _Transparency * falloffAlpha;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Transparent/VertexLit"
}
