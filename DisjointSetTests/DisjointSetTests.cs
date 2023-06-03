using DisjointSet;

namespace DisjointSetTests
{
    public class DisjointSetTests
    {
        [Fact]
        public void Smoke_Test()
        {
            var disjointSet = new DisjointSet<int>();

            for (int i = 1; i <= 7; i++) disjointSet.MakeSet(i);

            Assert.Equal(disjointSet.Count, 7);

            disjointSet.Union(1, 2);
            Assert.Equal(1, disjointSet.FindSet(2));

            disjointSet.Union(2, 3);
            Assert.Equal(1, disjointSet.FindSet(3));

            disjointSet.Union(4, 5);
            Assert.Equal(4, disjointSet.FindSet(5));

            disjointSet.Union(5, 6);
            Assert.Equal(4, disjointSet.FindSet(6));

            disjointSet.Union(6, 7);
            Assert.Equal(4, disjointSet.FindSet(7));

            disjointSet.Union(3, 4);
            Assert.Equal(1, disjointSet.FindSet(4));
        }
    }
}