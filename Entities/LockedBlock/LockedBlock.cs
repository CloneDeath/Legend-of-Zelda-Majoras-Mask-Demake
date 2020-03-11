using System.Linq;
using Godot;

namespace LoZMM.Entities.LockedBlock {
	public class LockedBlock : BaseEntity.BaseEntity, IPushable
	{
		public Entities.Player.Player GetPlayer() => GetTree().GetNodesInGroup("player").Cast<Entities.Player.Player>().FirstOrDefault();

		protected AudioStreamPlayer OpenSound => GetNode<AudioStreamPlayer>("OpenSound");

		public void Push(Vector2 direction) {
			var player = GetPlayer();
			if (player == null || !player.HasKey1) return;

			var sound = OpenSound;
			RemoveChild(sound);
			GetPlayer().AddChild(sound);
			sound.Play();

			QueueFree();
		}
	}
}
