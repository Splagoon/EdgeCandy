﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeCandy.Components;
using EdgeCandy.Framework;
using SFML.Graphics;
using SFML.Window;

namespace EdgeCandy.Objects
{
    public class Player : GameObject
    {
        public AnimatableGraphicsComponent Graphics = new AnimatableGraphicsComponent();
        public PhysicsComponent Physics = new PhysicsComponent();

        public Player()
        {
            Graphics.Sprite = new Sprite(Content.Player);
            Graphics.Animation = new Animation(1, 6, 0.667, true);
            Graphics.FrameSize = new Vector2i(32, 64);
        }

        public override void SyncComponents()
        {
            // Physics is the be-all end-all for position
            // We could have multiple graphics components, some physical some purely visual,
            // we could apply an offset here, etc.  Pretty powerful model.
            Graphics.Sprite.Position = Physics.Position;
        }
    }
}
