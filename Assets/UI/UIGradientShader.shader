Shader "UI/GradientOverlay"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _TopColor ("Top Color", Color) = (1,0,0,1)
        _BottomColor ("Bottom Color", Color) = (0,0,1,1)
        _MainTex ("MainTex", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue"="Overlay" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Lighting Off Cull Off ZWrite Off ZTest Always
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _TopColor;
            fixed4 _BottomColor;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
                fixed4 texColor = tex2D(_MainTex, uv);
                fixed4 gradientColor = lerp(_BottomColor, _TopColor, uv.y);
                fixed4 finalColor = texColor * gradientColor * _Color;
                return finalColor;
            }
            ENDCG
        }
    }
}
