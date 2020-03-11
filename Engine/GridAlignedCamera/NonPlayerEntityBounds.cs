using Godot;

namespace LoZMM.Engine.GridAlignedCamera {
	[Tool]
	public class NonPlayerEntityBounds : StaticBody2D {
		private Vector2 _size = new Vector2(160, 128);
		[Export] public Vector2 Size {
			get => _size;
			set {
				_size = value;
				RecalculateEdges();
			}
		}

		protected CollisionShape2D TopEdge => GetNode<CollisionShape2D>(nameof(TopEdge));
		protected CollisionShape2D RightEdge => GetNode<CollisionShape2D>(nameof(RightEdge));
		protected CollisionShape2D LeftEdge => GetNode<CollisionShape2D>(nameof(LeftEdge));
		protected CollisionShape2D BottomEdge => GetNode<CollisionShape2D>(nameof(BottomEdge));

		public override void _Ready() {
			RecalculateEdges();
		}

		public void RecalculateEdges() {
			if (TopEdge == null) return;
			TopEdge.Shape = new SegmentShape2D{A = Vector2.Zero, B = _size * Vector2.Right};
			RightEdge.Shape = new SegmentShape2D{A = _size * Vector2.Right, B = _size};
			LeftEdge.Shape = new SegmentShape2D{A = Vector2.Zero, B = _size * Vector2.Down};
			BottomEdge.Shape = new SegmentShape2D{A = _size * Vector2.Down, B = _size};
		}
	}
}
