using Godot;

namespace LoZMM.Entities.Door {
	public class Door : BaseEntity.BaseEntity {
		[Export] public bool DeleteOnActivate { get; set; }
		[Export] public bool ActivationOpens { get; set; } = false;
		[Export] public int ActivationThreshold { get; set; } = 1;

		protected AudioStreamPlayer OpenSound => GetNode<AudioStreamPlayer>("OpenSound");

		protected int ActivationLevel;

		public override void _Process(float delta) {
			base._Process(delta);

			if (ActivationOpens) {
				Sprite.Visible = ActivationLevel < ActivationThreshold;
				SetCollisionLayerBit(2, ActivationLevel < ActivationThreshold);
				SetCollisionLayerBit(6, ActivationLevel < ActivationThreshold);

			}
			else {
				Sprite.Visible = ActivationLevel >= ActivationThreshold;
				SetCollisionLayerBit(2, ActivationLevel >= ActivationThreshold);
				SetCollisionLayerBit(6, ActivationLevel >= ActivationThreshold);
			}
		}

		public void Activate() {
			ActivationLevel += 1;

			if (ActivationLevel >= ActivationThreshold) {
				if (DeleteOnActivate) {
					var sound = OpenSound;
					RemoveChild(sound);
					GetParent().AddChild(sound);
					sound.Play();
					QueueFree();
				}
				else {
					OpenSound.Play();
				}
			}
		}

		public void Deactivate() {
			ActivationLevel -= 1;
		}
	}
}
