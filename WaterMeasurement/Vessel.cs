using System;

namespace WaterMeasurement
{
  class Vessel
  {
    public int CurrentCapacity { get; set; }

    public readonly int VesselCapacity;
    public readonly string VesselName;

    public Vessel(int vesselCapacity, string vesselName)
    {
      this.VesselCapacity = vesselCapacity;
      this.VesselName = vesselName;
      this.CurrentCapacity = 0;
    }

    public void Replenish()
    {
      this.CurrentCapacity = this.VesselCapacity;
    }

    public void Pour()
    {
      this.CurrentCapacity = 0;
    }
  }
}