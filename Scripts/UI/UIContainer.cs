using Godot;
using System;
using DungeonRPG2.D.Scripts.UI;

public partial class UIContainer : VBoxContainer
{
    [Export] public ContainerType Container { get; private set; }
    [Export] public Button ButtonNode { get; private set; }
}
