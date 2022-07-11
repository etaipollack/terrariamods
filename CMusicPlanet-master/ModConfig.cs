using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace CMusicPlanet
{
    public class ModConfiguration : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        [Label("Planetoid Music")]
        [Tooltip("True to enable Planetoid music, false to disable. True by default")]
        public bool PlanetoidMusic;

        [DefaultValue(true)]
        [Label("Abyss Miniboss Music")]
        [Tooltip("True to enable Abyss Miniboss music, false to disable. True by default")]
        public bool WyrmMusic;


        public override ModConfig Clone()
        {
            var clone = (ModConfiguration)base.Clone();
            return clone;
        }

        public override void OnLoaded()
        {
            CMusicPlanet.modConfiguration = this;
        }

    }
}