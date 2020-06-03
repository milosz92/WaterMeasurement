using System;

namespace WaterMeasurement
{
  static class Helper
  {
    private static void Transfer(Vessel vesselToFill, Vessel vesselToTakeFrom)
    {
      Console.WriteLine($"State when transfer start.{vesselToFill.VesselName}: {vesselToFill.CurrentCapacity}, {vesselToTakeFrom.VesselName}: {vesselToTakeFrom.CurrentCapacity}");
      while (vesselToTakeFrom.CurrentCapacity > 0 && vesselToFill.CurrentCapacity < vesselToFill.VesselCapacity)
      {
        vesselToFill.CurrentCapacity++;
        vesselToTakeFrom.CurrentCapacity--;
        Console.WriteLine($"{vesselToFill.VesselName}: {vesselToFill.CurrentCapacity}, {vesselToTakeFrom.VesselName}: {vesselToTakeFrom.CurrentCapacity}");
      }
      Console.WriteLine($"State when transfer end.{vesselToFill.VesselName}: {vesselToFill.CurrentCapacity}, {vesselToTakeFrom.VesselName}: {vesselToTakeFrom.CurrentCapacity}");
    }

    private static void ShowVesselsLevel(Vessel vesselOne, Vessel vesselTwo, Vessel vesselThree)
    {
      Console.WriteLine($"All Vessels State. {vesselOne.VesselName}: {vesselOne.CurrentCapacity}. {vesselTwo.VesselName}: {vesselTwo.CurrentCapacity}. {vesselThree.VesselName}: {vesselThree.CurrentCapacity}.");
    }

    public static void HandleVesselsLevelToDesired(Vessel vesselThree, Vessel vesselSix, Vessel vesselTen, int desiredVal)
    {
      int tempDesiredVal = desiredVal;

      if (desiredVal - vesselTen.VesselCapacity >= 0)
      {
        vesselTen.Replenish();
        tempDesiredVal -= vesselTen.VesselCapacity;
      }
      if (tempDesiredVal - vesselSix.VesselCapacity >= 0)
      {
        vesselSix.Replenish();
        tempDesiredVal -= vesselSix.VesselCapacity;
      }
      if (tempDesiredVal - vesselThree.VesselCapacity >= 0)
      {
        vesselThree.Replenish();
        tempDesiredVal -= vesselThree.VesselCapacity;
      }

      bool isVesselThreeFilledOnStart = vesselThree.CurrentCapacity > 0 ? true : false;
      bool isVesselSixFilledOnStart = vesselSix.CurrentCapacity > 0 ? true : false;
      bool isVesselTenFilledOnStart = vesselTen.CurrentCapacity > 0 ? true : false;

      if (tempDesiredVal == 1)
      {
        Helper.MakeOneLiter(vesselThree, vesselSix, vesselTen);
        Helper.RestoreVesselsState(isVesselThreeFilledOnStart, isVesselSixFilledOnStart, isVesselTenFilledOnStart, vesselThree, vesselSix, vesselTen);
      }
      if (tempDesiredVal == 2)
      {
        Helper.MakeTwoLiters(vesselThree, vesselSix, vesselTen);
        Helper.RestoreVesselsState(isVesselThreeFilledOnStart, isVesselSixFilledOnStart, isVesselTenFilledOnStart, vesselThree, vesselSix, vesselTen);
      }
      Helper.ShowVesselsLevel(vesselThree, vesselSix, vesselTen);
    }

    private static void MakeOneLiter(Vessel vesselThree, Vessel vesselSix, Vessel vesselTen)
    {
      vesselThree.Pour();
      vesselSix.Pour();
      vesselTen.Pour();

      vesselTen.Replenish();

      Helper.Transfer(vesselSix, vesselTen);
      Helper.Transfer(vesselThree, vesselTen);
      vesselThree.Pour();
      vesselSix.Pour();
    }

    private static void MakeTwoLiters(Vessel vesselThree, Vessel vesselSix, Vessel vesselTen)
    {
      Helper.MakeOneLiter(vesselThree, vesselSix, vesselTen);
      Helper.Transfer(vesselSix, vesselTen);
      vesselTen.Replenish();
      Helper.Transfer(vesselThree, vesselTen);
      vesselThree.Pour();
      Helper.Transfer(vesselThree, vesselTen);
      vesselThree.Pour();
      Helper.Transfer(vesselThree, vesselTen);
      vesselThree.Pour();
      Helper.Transfer(vesselTen, vesselSix);
    }

    private static void RestoreVesselsState(bool isVesselThreeFilledOnStart, bool isVesselSixFilledOnStart, bool isVesselTenFilledOnStart, Vessel vesselThree, Vessel vesselSix, Vessel vesselTen)
    {
      if (isVesselTenFilledOnStart)
      {
        if (!isVesselThreeFilledOnStart)
        {
          Helper.Transfer(vesselThree, vesselTen);
        }
        else if (!isVesselSixFilledOnStart)
        {
          Helper.Transfer(vesselSix, vesselTen);
        }
      }

      if (isVesselTenFilledOnStart)
      {
        vesselTen.Replenish();
      }
      if (isVesselSixFilledOnStart)
      {
        vesselSix.Replenish();
      }
      if (isVesselThreeFilledOnStart)
      {
        vesselThree.Replenish();
      }
    }
  }
}
