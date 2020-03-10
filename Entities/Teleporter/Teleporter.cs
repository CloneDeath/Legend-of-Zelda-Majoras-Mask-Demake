using Godot;

namespace LegendsOfLove.Entities.Teleporter {
	public class Teleporter : Area2D
	{
		[Export] public NodePath Destination { get; set; }

		protected AudioStreamPlayer TeleportSound => GetNode<AudioStreamPlayer>("TeleportSound");

		public void _on_Teleporter_body_entered(Node body) {
			if (!(body is Player.Player player)) return;

			var destination = GetNode<Node2D>(Destination);
			player.TeleportTo(destination.GlobalPosition);

			TeleportSound.Play();
		}
	}
}
