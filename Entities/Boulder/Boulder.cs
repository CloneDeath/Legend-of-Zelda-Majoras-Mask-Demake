using Godot;

namespace LoZMM.Entities.Boulder {
	public class Boulder : BaseEntity.BaseEntity, IHammerable
	{
		public void Hammer(Vector2 direction) {
			Sprite.Visible = false;
			SetCollisionLayerBit(2, false);
			SetCollisionLayerBit(6, false);
		}

		public override void Reset() {
			base.Reset();

			Sprite.Visible = true;
			SetCollisionLayerBit(2, true);
			SetCollisionLayerBit(6, true);
		}
	}
}
