using Godot;
using LegendsOfLove.Entities.Items.Keys;

namespace LegendsOfLove.Entities.Enemies.Slime {
	public class GiantSlime : Slime {
		[Export] public bool DropsKeyOnDeath { get; set; } = true;

		public override void OnDeath() {
			base.OnDeath();

			if (DropsKeyOnDeath) {
				var heart = (Key1) ResourceLoader.Load<PackedScene>("res://Entities/Items/Keys/Key1.tscn").Instance();
				GetParent().AddChild(heart);
				heart.Position = Position;
			}
			QueueFree();
		}
	}
}
