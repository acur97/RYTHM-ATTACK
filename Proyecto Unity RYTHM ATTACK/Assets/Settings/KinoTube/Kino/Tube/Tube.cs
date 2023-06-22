// KinoTube - Old TV/video artifacts simulation
// https://github.com/keijiro/KinoTube

using UnityEngine;

namespace Kino
{
    [ExecuteInEditMode]
    public class Tube : MonoBehaviour
    {
        #region Editable attributes

        [SerializeField, Range(0, 1)] float _bleeding = 0.5f;
        [SerializeField, Range(0, 1)] float _fringing = 0.5f;
        [SerializeField, Range(0, 1)] float _scanline = 0.5f;

        #endregion

        #region Private resources

        [SerializeField] Shader _shader;
        Material _material;
        private readonly int _BleedTaps = Shader.PropertyToID("_BleedTaps");
        private readonly int _BleedDelta = Shader.PropertyToID("_BleedDelta");
        private readonly int _FringeDelta = Shader.PropertyToID("_FringeDelta");
        private readonly int _Scanline = Shader.PropertyToID("_Scanline");

        private float bleedWidth = 0;
        private float bleedStep = 0;
        private int bleedTaps = 0;
        private float bleedDelta = 0;
        private float fringeWidth = 0;

        #endregion

        #region MonoBehaviour methods

        void OnDestroy()
        {
            if (_material == null)
            {
                if (Application.isPlaying)
                    Destroy(_material);
                else
                    DestroyImmediate(_material);
            }
        }

        void OnRenderImage(RenderTexture source, RenderTexture dest)
        {
            if (_material == null)
            {
                _material = new Material(_shader)
                {
                    hideFlags = HideFlags.DontSave
                };
            }

            //var bleedWidth = 0.04f * _bleeding;  // width of bleeding
            //var bleedStep = 2.5f / source.width; // max interval of taps
            //var bleedTaps = Mathf.CeilToInt(bleedWidth / bleedStep);
            //var bleedDelta = bleedWidth / bleedTaps;
            //var fringeWidth = 0.0025f * _fringing; // width of fringing

            bleedWidth = 0.04f * _bleeding;  // width of bleeding
            bleedStep = 2.5f / source.width; // max interval of taps
            bleedTaps = Mathf.CeilToInt(bleedWidth / bleedStep);
            bleedDelta = bleedWidth / bleedTaps;
            fringeWidth = 0.0025f * _fringing; // width of fringing

            _material.SetInt(_BleedTaps, bleedTaps);
            _material.SetFloat(_BleedDelta, bleedDelta);
            _material.SetFloat(_FringeDelta, fringeWidth);
            _material.SetFloat(_Scanline, _scanline);

            Graphics.Blit(source, dest, _material, 0);
        }

        #endregion
    }
}
