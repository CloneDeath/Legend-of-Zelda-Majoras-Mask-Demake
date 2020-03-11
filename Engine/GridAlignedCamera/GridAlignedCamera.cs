using System.Collections.Generic;
using System.Linq;
using Godot;
using LoZMM.Entities.BaseEntity;
using LoZMM.Entities.Player;

namespace LoZMM.Engine.GridAlignedCamera {
	[Tool]
	public partial class GridAlignedCamera : Node2D {
		private Vector2 _tileSize = new Vector2(16, 16);
		[Export] public Vector2 TileSize {
			get => _tileSize;
			set {
				_tileSize = value;
				RecalculateBounds();
			} 
		}

		private Vector2 _cellSize = new Vector2(10, 8);
		[Export] public Vector2 CellSize {
			get => _cellSize;
			set {
				_cellSize = value;
				RecalculateBounds();
			}
		}
		public Vector2 PixelsPerCell => CellSize * TileSize;
		
		protected Queue<TransitionAction> TransitionQueue = new Queue<TransitionAction>();

		public override void _Ready() {
			RecalculateBounds();
		}

		public void RecalculateBounds() {
			if (NonPlayerEntityBounds == null) return;
			
			NonPlayerEntityBounds.Size = PixelsPerCell;
			ContentsShape.Shape = new RectangleShape2D {
				Extents = PixelsPerCell / 2
			};
			ContentsShape.Position = PixelsPerCell / 2;
			TopEdge.Shape = new SegmentShape2D{A = Vector2.Zero, B = PixelsPerCell * Vector2.Right};
			RightEdge.Shape = new SegmentShape2D{A = PixelsPerCell * Vector2.Right, B = PixelsPerCell};
			LeftEdge.Shape = new SegmentShape2D{A = Vector2.Zero, B = PixelsPerCell * Vector2.Down};
			BottomEdge.Shape = new SegmentShape2D{A = PixelsPerCell * Vector2.Down, B = PixelsPerCell};
		}

		public override void _PhysicsProcess(float delta) {
			if (Godot.Engine.EditorHint) return;
			Camera2D.GlobalPosition = GlobalPosition.Round();
			CheckForTransitions();
		}

		protected void CheckForTransitions() {
			if (!CanTransition) return;
			if (!TransitionQueue.Any()) return;

			var action = TransitionQueue.Dequeue();
			Transition(action.Direction, action.Player);
		}

		public void _on_Player_body_entered(Node body, Vector2 direction) {
			if (Godot.Engine.EditorHint) return;
			
			if (!(body is Player player)) return;
			if (!CanTransition) {
				TransitionQueue.Enqueue(new TransitionAction(player, direction));
				return;
			}

			Transition(direction, player);
		}

		protected bool CanTransition => !Tween.IsActive();

		protected List<BaseEntity> GetCurrentEntitiesOnScreen() {
			var rect = new Rect2(GlobalPosition, PixelsPerCell);
			var entities = GetTree().GetNodesInGroup("entity").Cast<BaseEntity>();
			return entities.Where(entity => rect.HasPoint(entity.GlobalPosition)).ToList();
		}

		protected void Transition(Vector2 direction, Player player) {
			Tween.RemoveAll();

			var oldEntities = GetCurrentEntitiesOnScreen();
			foreach (var entity in oldEntities) {
				entity.Freeze();
			}

			var delta = direction * PixelsPerCell;
			Tween.InterpolateProperty(this, nameof(Position),
				Position, Position + delta, 1);

			var playerDelta = direction * TileSize;
			Tween.InterpolateProperty(player, nameof(player.Position),
				player.Position, player.Position + playerDelta, 1);
			Tween.InterpolateCallback(player, 1, nameof(player.Unfreeze));

			foreach (var entity in oldEntities) {
				if (entity.DoesNotReset) continue;
				Tween.InterpolateCallback(entity, 1, nameof(entity.Reset));
			}
			Tween.InterpolateDeferredCallback(this, 1, nameof(UnfreezeNew));

			player.Freeze();
			Tween.Start();
		}

		public void UnfreezeNew() {
			var newEntities = GetCurrentEntitiesOnScreen();
			foreach (var entity in newEntities) {
				entity.Unfreeze();
			}
		}

		public void FadeIn() => AnimationPlayer.Play("FadeIn");
		public void FadeOut() => AnimationPlayer.Play("FadeOut");

		public void _on_ContentsArea2D_body_exited(Node body) {
			if (Godot.Engine.EditorHint) return;
			
			if (body is Player player) {
				var oldEntities = GetCurrentEntitiesOnScreen();
				foreach (var entity in oldEntities) {
					entity.Freeze();
					entity.Reset();
				}
				
				var playerPosition = player.GlobalPosition;
				var playerCell = (playerPosition / PixelsPerCell).Floor();
				GlobalPosition = playerCell * PixelsPerCell;
				
				var newEntities = GetCurrentEntitiesOnScreen();
				foreach (var entity in newEntities) {
					entity.Unfreeze();
				}
			}
		}
	}
}
