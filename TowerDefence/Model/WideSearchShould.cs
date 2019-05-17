using System.Drawing;
using NUnit.Framework;

namespace TowerDefence.Model
{
    [TestFixture]
    public class WideSearchShould
    {
        [Test]
        public void Correct4X4()
        {
            var map = new Map(4,4,new Point(0,0),new Point(3,3),1 );
            var result = WideSearch.FindPaths(map, new Point(0, 0)).ToList();
            Assert.AreEqual(6,result.Count); 
            
        }
        
    }
}