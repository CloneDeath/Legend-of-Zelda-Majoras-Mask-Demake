using System.Linq;
using Godot;

namespace LoZMM.Entities.Player.HUD {
	public class Key1Indicator : Sprite
	{
		public Player GetPlayer() => GetTree().GetNodesInGroup("player").Cast<Player>().FirstOrDefault();

		public override void _Process(float delta) {
			var player = GetPlayer();
			if (player == null) return;

			Visible = player.HasKey1;
		}
	}
}
