﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeCandy.Components;
using EdgeCandy.Framework;
using EdgeCandy.Subsystems;
using SFML.Graphics;
using SFML.Window;

namespace EdgeCandy.States
{
    public class GameOverState : IGameState
    {
        private AnimatableGraphicsComponent noise = new AnimatableGraphicsComponent();
        private TimerComponent restartTimer = new TimerComponent(1);
        private CameraComponent camera;

        public GameOverState()
        {
            noise.Sprite = new Sprite(Content.Noise);
            noise.FrameSize = new Vector2i((int)Graphics.Width, (int)Graphics.MaxHeight);
            noise.Animation = new Animation(0, 2, 0.1, true);

            GraphicsSubsystem.Instance.SwitchCamera(null);

            restartTimer.DingDingDing += (sender, args) => Program.ChangeState<GameplayState>();
            restartTimer.Start();
        }

        public void Update(double elapsedTime)
        {
            UpdateSubsystem.Instance.Update(elapsedTime);
        }

        public void Draw(double elapsedTime)
        {
            GraphicsSubsystem.Instance.Draw();
        }
    }
}