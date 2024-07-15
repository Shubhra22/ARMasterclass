Shader "Custom/TiledTextureWithZFightingPrevention"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TileSize ("Tile Size", Float) = 1.0
        _DepthOffset ("Depth Offset", Float) = 0.0001
    }
    SubShader
    {
        Tags {"Queue"="Geometry" "RenderType"="Opaque"}
        LOD 100
        ZWrite Off
        Offset -100, -100
        
        CGPROGRAM
        #pragma surface surf Lambert vertex:vert

        sampler2D _MainTex;
        float _TileSize;
        float _DepthOffset;

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v)
        {
            // Slightly adjust the vertex position along its normal to prevent z-fighting
            v.vertex.xyz += v.normal * _DepthOffset;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Calculate tiled UV coordinates
            float2 tiledUV = frac(IN.uv_MainTex * _TileSize);
            
            // Sample the texture using the tiled UV coordinates
            fixed4 c = tex2D (_MainTex, tiledUV);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}