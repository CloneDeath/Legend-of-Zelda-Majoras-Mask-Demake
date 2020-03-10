using System.Linq;
using Godot;

namespace LegendsOfLove.Entities.Player.HUD {
	public class HammerIndicator : Sprite
	{
		public Player GetPlayer() => GetTree().GetNodesInGroup("player").Cast<Player>().FirstOrDefault();

		public override void _Process(float delta) {
			var player = GetPlayer();
			if (player == null) return;

			Visible = player.HasHammer;
		}
	}
}
