using Godot;
using Tooltip;

namespace tooltip.example;

[GlobalClass]
public partial class Test : Node2D
{
	[Export]
	[Tooltip("My Fancy Resource")]
	public Resource my_resource;
}