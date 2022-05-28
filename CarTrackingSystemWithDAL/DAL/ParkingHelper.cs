using CarTrackingSystemWithDAL.Data;
using CarTrackingSystemWithDAL.Models;

namespace CarTrackingSystemWithDAL.DAL; 

public class ParkingHelper {
    private readonly  ParkingContext _parkingContext;
    
    public ParkingHelper(ParkingContext context) {
        _parkingContext = context;
    }

    public virtual Pass CreatePass(string purchaser, bool premium, int capacity) {
        Pass newPass = new Pass {
            Purchaser = purchaser,
            Premium = premium,
            Capacity = capacity
        };

        _parkingContext.Passes.Add(newPass);
        _parkingContext.SaveChanges();

        return newPass;
    } 

    public virtual ParkingSpot CreateParkingSpot()  {
        ParkingSpot newSpot = new ParkingSpot {
            Occupied = false
        };

        _parkingContext.ParkingSpots.Add(newSpot);
        return newSpot;
    }
}
