Shader "Custom/DepthOnlyShader" {
    SubShader {
        Tags { "Queue" = "0" }
        Pass {
            ZWrite On
            ColorMask 0

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            // No need for UNITY_SINGLE_PASS_STEREO, because multi-pass stereo handles this automatically

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 pos : SV_POSITION;
            };

            v2f vert(appdata v) {
                v2f o;
                // Multi-pass stereo does not need special handling, we just use UnityObjectToClipPos
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            float4 frag(v2f i) : SV_Target {
                // No RGB output, just depth writing
                return float4(0, 0, 0, 0);
            }

            ENDCG
        }
    }

    FallBack "Diffuse"
}
