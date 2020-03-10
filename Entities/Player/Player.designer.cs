using Godot;

namespace LegendsOfLove.Entities.Player {
	public partial class Player {
		protected Sprite Gravestone => GetNode<Sprite>("Gravestone");
		protected PlayerAnimation PlayerAnimation => GetNode<PlayerAnimation>("PlayerAnimation");
		protected Tween TeleportTween => GetNode<Tween>("TeleportTween");
		protected RayCast2D PushSensor => GetNode<RayCast2D>("PushSensor");
		protected Area2D HammerArea => GetNode<Area2D>("HammerArea");
		protected Area2D DamageArea => GetNode<Area2D>("DamageArea");
		protected Tween ResetPlayerTween => GetNode<Tween>("ResetPlayerTween");
		public AudioStreamPlayer PickupHeartSound => GetNode<AudioStreamPlayer>("PickupHeartSound");
		public AudioStreamPlayer HitSound => GetNode<AudioStreamPlayer>("HitSound");
	}
}