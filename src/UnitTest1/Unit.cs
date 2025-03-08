using System;
using Xunit;
using ExamApp;

namespace UnitTest1
{
    [Fact]
    public class UnitTest1
    {
        Graph graph = new Graph();

        graph.InitializeGraph(); 

        Assert.NotNull(graph.AdjacencyMatrix);
        Assert.True(graph.AdjacencyMatrix[0, 1]);

        Assert.False(graph.AdjacencyMatrix[0, 2]);

        Assert.Equal(graph.AdjacencyMatrix[0, 1], graph.AdjacencyMatrix[1, 0]);
    }
}