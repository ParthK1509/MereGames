using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceHandHeld : StandardControls.IGamePlayControlsActions //telling interface to include all inputs from our StandardControls
{
  void OnAttachedCarrier();
  void OnEquip();
  void OnUnequip();
}
