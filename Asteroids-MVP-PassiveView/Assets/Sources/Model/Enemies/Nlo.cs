﻿using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Nlo : Enemy
    {
        private readonly float _speed;

        public Transformable Target { get; private set; }

        public Nlo(Transformable target, Vector2 position, float speed) : base(position, 0)
        {
            Target = target;
            _speed = speed;
        }

        public void SetupTarget(Transformable target)
        {
            Target = target;
        }

        public override void Update(float deltaTime)
        {
            if (Target != null)
            {
                Vector2 nextPosition = Vector2.MoveTowards(Position, Target.Position, _speed * deltaTime);
                MoveTo(nextPosition);
                LookAt(Target.Position);
            }
        }

        private void LookAt(Vector2 point)
        {
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, (Position - point)));
        }
    }
}
