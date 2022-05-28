using CarTrackingSystemWithDAL.DAL;
using CarTrackingSystemWithDAL.Data;
using CarTrackingSystemWithDAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarTrackingSystemUnitTesting;

[TestClass]
public class UnitTest1 {
    private Mock<ParkingHelper> _mockParkingHelper;
    private Pass _pass1 = new() {
        Purchaser = "demo pass 1",
        Premium = true,
        Capacity = 1
    };
    
    private Pass _pass2 = new() {
        Purchaser = "demo pass 2",
        Premium = false,
        Capacity = 3
    };
    
    ParkingSpot _newSpot = new ParkingSpot {
        Occupied = false
    };
    
    ParkingSpot _newSpot2 = new ParkingSpot {
        Occupied = true
    };
    
    [TestInitialize]
    public void Initialize() {
        Mock<ParkingContext> parkingContextMock = new Mock<ParkingContext>();
        _mockParkingHelper = new Mock<ParkingHelper>(parkingContextMock.Object);
        _mockParkingHelper.Setup(m => m.CreatePass(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<int>())).Returns(new Pass());
        _mockParkingHelper.Setup(m => m.CreateParkingSpot()).Returns(new ParkingSpot());
    }
    
    [TestMethod]
    public void CreatePassReturnsCreatedPass() {
        // Arrange
        
        // Act
        Pass pass = _mockParkingHelper.Object.CreatePass("demo pass 1", true, 1);
        
        // Assert
        Assert.AreSame(_pass1, pass);
    }
    
    [TestMethod]
    public void CreateParkingSlotReturnsCreatedParkingSlot() {
        // Arrange
        
        // Act
        ParkingSpot spot = _mockParkingHelper.Object.CreateParkingSpot();
        
        // Assert
        Assert.AreSame(_newSpot, spot);
    }
}
