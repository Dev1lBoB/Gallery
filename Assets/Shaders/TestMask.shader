Shader "Custom/TestMask"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200
        Stencil
        {
            Ref 1
            Comp Always
            Pass Replace
        }

        CGPROGRAM
        #pragma surface surf Lambert alpha

        struct Input
        {
            float3 Albedo;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = fixed3(1, 1, 1);
            o.Alpha = 0;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
