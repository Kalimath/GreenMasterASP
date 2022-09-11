using Xunit;

namespace GreenMaster.Tests.Models.Specie;

public class SpecieCtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenScientificNameNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var specie = new GreenMaster.Models.Plants.Specie() { ScientificName = null! };
        });
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenCommonNameNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var specie = new GreenMaster.Models.Plants.Specie() { CommonName = null! };
        });
    }
    
    [Fact]
    public void ThrowArgumentException_WhenScientificAndCommonNameNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var specie = new GreenMaster.Models.Plants.Specie() { ScientificName = null!, CommonName = null! };
        });
        Assert.Throws<ArgumentException>(() =>
        {
            var specie = new GreenMaster.Models.Plants.Specie() { ScientificName = "", CommonName = null! };
        });
        Assert.Throws<ArgumentException>(() =>
        {
            var specie = new GreenMaster.Models.Plants.Specie() { ScientificName = "", CommonName = "" };
        });
    }
}