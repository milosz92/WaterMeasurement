namespace WaterMeasurement
{
  class Program
  {
    static void Main(string[] args)
    {
      //range <1-19>
      int desiredVal = 19;
      Vessel vessel3 = new Vessel(3, "VesselThree");
      Vessel vessel6 = new Vessel(6, "VesselSix");
      Vessel vessel10 = new Vessel(10, "VesselTen");

      Helper.HandleVesselsLevelToDesired(vessel3, vessel6, vessel10, desiredVal);
    }
  }
}