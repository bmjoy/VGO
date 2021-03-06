﻿// ----------------------------------------------------------------------
// @Namespace : UniGLTFforUniVgo
// @Class     : VGO_PS_ColorBySpeedModule
// ----------------------------------------------------------------------
namespace UniGLTFforUniVgo
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// VGO Particle System ColorBySpeedModule
    /// </summary>
    [Serializable]
    [JsonObject("vgo.ps.colorBySpeedModule")]
    public class VGO_PS_ColorBySpeedModule
    {
        /// <summary>Specifies whether the ColorBySpeedModule is enabled or disabled.</summary>
        [JsonProperty("enabled")]
        public bool enabled;

        /// <summary>The gradient that controls the particle colors.</summary>
        [JsonProperty("color")]
        public VGO_PS_MinMaxGradient color;

        /// <summary>Apply the color gradient between these minimum and maximum speeds.</summary>
        [JsonProperty("range")]
        //public Vector2 range;
        public float[] range;
    }
}
