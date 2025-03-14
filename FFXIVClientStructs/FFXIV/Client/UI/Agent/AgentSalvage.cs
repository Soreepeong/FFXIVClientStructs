﻿using System;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent; 

[Agent(AgentId.Salvage)]
[StructLayout(LayoutKind.Explicit, Size = 0x3E0)]
public unsafe struct AgentSalvage {
    public AgentSalvage* Instance() => Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentSalvage();
    
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x398)] public InventoryItem* DesynthItemSlot;

    [FieldOffset(0x3B0)] public SalvageResult DesynthItem;
    [FieldOffset(0x3BC)] public uint DesynthItemId;
    
    [FixedArray(typeof(SalvageResult), 3)]
    [FieldOffset(0x3C0)] public fixed byte DesynthResult[8 * 3];

    public Span<SalvageResult> DesynthResultSpan {
        get {
            fixed (byte* ptr = DesynthResult)
                return new Span<SalvageResult>(ptr, 3);
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct SalvageResult {
    [FieldOffset(0x00)] public uint ItemId;
    [FieldOffset(0x04)] public int Quantity;
}