Shader "Custom/ScreenStencilMask"
{
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Stencil
        {
            Ref 1
            Comp always
            Pass replace
        }
        Pass
        {
            // Optional: Render the screen as a specific color to help debug masking
            Color (0, 0, 0, 0)
        }
    }
}
