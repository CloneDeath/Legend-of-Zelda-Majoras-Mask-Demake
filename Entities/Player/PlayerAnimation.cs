using System;
using Godot;

namespace LoZMM.Entities.Player {
	public class PlayerAnimation : AnimationPlayer
	{
		public void SetAnimation(string type, Vector2 direction) {
			var animationName = GetAnimationName(type, direction);
			if (CurrentAnimation == animationName) return;
			Play(animationName);
		}

		protected string GetAnimationName(string type, Vector2 direction) {
			return $"{type}_{GetAnimationDirection(direction)}";
		}
		
		protected string GetAnimationDirection(Vector2 direction) {
			if (direction == Vector2.Down) return "Down";
			if (direction == Vector2.Up) return "Up";
			if (direction == Vector2.Left) return "Left";
			if (direction == Vector2.Right) return "Right";
			throw new NotImplementedException();
		}
	}
}
