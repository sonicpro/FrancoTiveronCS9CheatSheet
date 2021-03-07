using FrancoTiveronCS9CheatSheet.Pattern_Matching.Type_Pattern_in_Switch;
using Xunit;
using static FrancoTiveronCS9CheatSheet.Pattern_Matching.Type_Pattern_in_Switch.VolumeCalculator;

namespace XUnitTests
{
    public class TypePattern
    {
        [Fact]
        public void Test()
        {
            var cube = new Cube { Side = 12.4 };

            var cone = new Cone
            {
                Radius = 18.2,
                Height = 17.4
            };

            Assert.All(new object[2] { cube, cone }, solid => Assert.Equal(GetVolumeWithIsStatement(solid), GetVolumeSwitchStatementWithTypePattern(solid)));

            Assert.All(new object[2] { cube, cone }, solid => Assert.Equal(GetVolumeWithIsStatement(solid), GetVolumeSwithExpressionWithTypePattern(solid)));
        }
    }
}
