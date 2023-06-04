using Infraestructure;
using Infraestructure.Models;
using Moq;

namespace Domain.Test;

public class UnitTest1
{
    [Fact]
    public void Create_ValidOwner_ReturnSuccess()
    {
        //Arrage
        Owner owner = new Owner()
        {
            firstName = "Hannibal",
            lastName = "Smith",
            age = 19,
            phone = "938271278"
        };
        var mockOwnerInfraestructure = new Mock<IOwnerInfraestructure>();
        mockOwnerInfraestructure.Setup(r => r.Create(owner)).Returns(true);
        OwnerDomain ownerDomain = new OwnerDomain(mockOwnerInfraestructure.Object);
        
        //Act
        var returnValue = ownerDomain.Create(owner);
        
        //Assert
        Assert.True(returnValue);
    }
    
    [Fact]
    public void Create_ValidOwner_ReturnError()
    {
        //Arrage
        Owner owner = new Owner()
        {
            firstName = "Hannibal",
            lastName = "Smith",
            age = 19,
            phone = "938271278"
        };
        var mockOwnerInfraestructure = new Mock<IOwnerInfraestructure>();
        mockOwnerInfraestructure.Setup(r => r.Create(owner)).Returns(false);
        OwnerDomain ownerDomain = new OwnerDomain(mockOwnerInfraestructure.Object);
        
        //Act
        var returnValue = ownerDomain.Create(owner);
        
        //Assert
        Assert.False(returnValue);
    }
    
    [Fact]
    public void Create_ValidOwner_ReturnException()
    {
        //Arrage
        Owner owner = new Owner()
        {
            firstName = "Hannibal",
            lastName = "Smith",
            age = 16,
            phone = "938271278"
        };
        var mockOwnerInfraestructure = new Mock<IOwnerInfraestructure>();
        mockOwnerInfraestructure.Setup(r => r.Create(owner)).Returns(false);
        OwnerDomain ownerDomain = new OwnerDomain(mockOwnerInfraestructure.Object);
        
        //Act
        var excepted = Assert.Throws<Exception>(() => ownerDomain.Create(owner));
        
        //Assert
        Assert.Equal("Debes ser mayor de edad", excepted.Message);
    }
}