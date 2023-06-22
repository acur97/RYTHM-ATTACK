using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Image Effects/Color Adjustments/Contrast Enhance (Unsharp Mask)")]
    public class ContrastEnhance : PostEffectsBase
	{
        [Range(0.0f, 1.0f)]
        public float intensity = 0.5f;
        [Range(0.0f,0.999f)]
        public float threshold = 0.0f;

        private Material separableBlurMaterial;
        private Material contrastCompositeMaterial;

        [Range(0.0f,1.0f)]
        public float blurSpread = 1.0f;

        public Shader separableBlurShader = null;
        public Shader contrastCompositeShader = null;

        private readonly int __MainTexBlurred = Shader.PropertyToID("_MainTexBlurred");
        private readonly int _intensity = Shader.PropertyToID("intensity");
        private readonly int _threshold = Shader.PropertyToID("threshold");
        private readonly string _offsets = "offsets";

        private int rtW = 0;
        private int rtH = 0;
        private RenderTexture color2;
        private RenderTexture color4a;
        private RenderTexture color4b;

        public override bool CheckResources ()
		{
            CheckSupport (false);

            contrastCompositeMaterial = CheckShaderAndCreateMaterial (contrastCompositeShader, contrastCompositeMaterial);
            separableBlurMaterial = CheckShaderAndCreateMaterial (separableBlurShader, separableBlurMaterial);

            if (!isSupported)
                ReportAutoDisable ();
            return isSupported;
        }

        void OnRenderImage (RenderTexture source, RenderTexture destination)
		{
            if (CheckResources()==false)
			{
                Graphics.Blit (source, destination);
                return;
            }

            rtW = source.width;
            rtH = source.height;

            color2 = RenderTexture.GetTemporary (rtW/2, rtH/2, 0);

            // downsample

            Graphics.Blit (source, color2);
            color4a = RenderTexture.GetTemporary (rtW/4, rtH/4, 0);
            Graphics.Blit (color2, color4a);
            RenderTexture.ReleaseTemporary (color2);

            // blur

            separableBlurMaterial.SetVector (_offsets, new Vector4 (0.0f, (blurSpread * 1.0f) / color4a.height, 0.0f, 0.0f));
            color4b = RenderTexture.GetTemporary (rtW/4, rtH/4, 0);
            Graphics.Blit (color4a, color4b, separableBlurMaterial);
            RenderTexture.ReleaseTemporary (color4a);

            separableBlurMaterial.SetVector (_offsets, new Vector4 ((blurSpread * 1.0f) / color4a.width, 0.0f, 0.0f, 0.0f));
            color4a = RenderTexture.GetTemporary (rtW/4, rtH/4, 0);
            Graphics.Blit (color4b, color4a, separableBlurMaterial);
            RenderTexture.ReleaseTemporary (color4b);

            // composite

            contrastCompositeMaterial.SetTexture (__MainTexBlurred, color4a);
            contrastCompositeMaterial.SetFloat (_intensity, intensity);
            contrastCompositeMaterial.SetFloat (_threshold, threshold);
            Graphics.Blit (source, destination, contrastCompositeMaterial);

            RenderTexture.ReleaseTemporary (color4a);
        }
    }
}
