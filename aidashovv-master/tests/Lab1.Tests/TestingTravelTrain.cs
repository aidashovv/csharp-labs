using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Result;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class TestingTravelTrain
{
    [Fact]
    public void Test1()
    {
        // arrange
        ITrain train = new Train(new Mass(1000.0), 0.0, 0.0, 5000.0);
        const double routeSpeedLimit = 120.0;

        var routeSegments = new Collection<IRouteSegment>()
        {
            new PoweredRouteSegment(1000.0, new Distance(2000.0, 5.0)),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
        };

        var route = new Route(routeSegments, routeSpeedLimit);

        // act
        ResultType result = route.LetsGoPassedPath(train);

        // assert
        Assert.True(result.IsSuccess, "Success");
        Assert.InRange(train.Speed, 110.9, 115.1);
    }

    [Fact]
    public void Test2()
    {
        // arrange
        ITrain train = new Train(new Mass(1000.0), 0.0, 0.0, 5000.0);
        const double routeSpeedLimit = 70.0;

        var routeSegments = new Collection<IRouteSegment>()
        {
            new PoweredRouteSegment(1000.0, new Distance(2000.0, 5.0)),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
        };

        var route = new Route(routeSegments, routeSpeedLimit);

        // act
        ResultType result = route.LetsGoPassedPath(train);

        // assert
        Assert.False(result.IsSuccess, "Failure");
        Assert.InRange(train.Speed, 110.9, 115.1);
        Assert.Equal(0, result.Time);
    }

    [Fact]
    public void Test3()
    {
        // arrange
        ITrain train = new Train(new Mass(1000.0), 0.0, 0.0, 5000.0);
        const double routeSpeedLimit = 150.0;

        var routeSegments = new Collection<IRouteSegment>()
        {
            new PoweredRouteSegment(1000.0, new Distance(2000.0, 5.0)),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
            new Station(5, 3, 110.0),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
        };

        var route = new Route(routeSegments, routeSpeedLimit);

        // act
        ResultType result = route.LetsGoPassedPath(train);

        // assert
        Assert.True(result.IsSuccess, "Success");
        Assert.InRange(train.Speed, 134.8, 135.4);
    }

    [Fact]
    public void Test4()
    {
        // arrange
        ITrain train = new Train(new Mass(1000.0), 0.0, 0.0, 5000.0);
        const double routeSpeedLimit = 97.0;

        var routeSegments = new Collection<IRouteSegment>()
        {
            new PoweredRouteSegment(1000.0, new Distance(2000.0, 5.0)),
            new Station(10, 10, 60.0),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
        };

        var route = new Route(routeSegments, routeSpeedLimit);

        // act
        ResultType result = route.LetsGoPassedPath(train);

        // assert
        Assert.False(result.IsSuccess, "Failure");
        Assert.InRange(train.Speed, 94.5, 96.5);
    }

    [Fact]
    public void Test5()
    {
        // arrange
        ITrain train = new Train(new Mass(1000.0), 0.0, 0.0, 5000.0);
        const double routeSpeedLimit = 90.0;

        var routeSegments = new Collection<IRouteSegment>()
        {
            new PoweredRouteSegment(1000.0, new Distance(2000.0, 5.0)),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
            new Station(10, 10, 83.0),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
        };

        var route = new Route(routeSegments, routeSpeedLimit);

        // act
        ResultType result = route.LetsGoPassedPath(train);

        // assert
        Assert.False(result.IsSuccess, "Failure");
        Assert.InRange(train.Speed, 114.9, 115.8);
    }

    [Fact]
    public void Test6()
    {
        // arrange
        ITrain train = new Train(new Mass(1000.0), 0.0, 0.0, 10000.0);
        const double routeSpeedLimit = 190.0;

        var routeSegments = new Collection<IRouteSegment>()
        {
            new PoweredRouteSegment(2000.0, new Distance(1000.0, 5.0)),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
            new PoweredRouteSegment(-1000.0, new Distance(1000.0, 5.0)),
            new Station(5, 10, 100.0),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
            new PoweredRouteSegment(2000.0, new Distance(1000.0, 5.0)),
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
            new PoweredRouteSegment(-1000.0, new Distance(1000.0, 5.0)),
        };

        var route = new Route(routeSegments, routeSpeedLimit);

        // act
        ResultType result = route.LetsGoPassedPath(train);

        // assert
        Assert.True(result.IsSuccess, "Success");
        Assert.InRange(train.Speed, 154.9, 155.1);
    }

    [Fact]
    public void Test7()
    {
        // arrange
        ITrain train = new Train(new Mass(1000.0), 0.0, 0.0, 5000.0);
        const double routeSpeedLimit = 50.0;

        var routeSegments = new Collection<IRouteSegment>()
        {
            new SimpleRouteSegment(new Distance(1000.0, 5.0)),
        };

        var route = new Route(routeSegments, routeSpeedLimit);

        // act
        ResultType result = route.LetsGoPassedPath(train);

        // assert
        Assert.False(result.IsSuccess, "Success");
        Assert.Equal(0.0, train.Speed);
    }

    [Fact]
    public void Test8()
    {
        // arrange
        ITrain train = new Train(new Mass(1000.0), 0.0, 0.0, 10000.0);
        const double routeSpeedLimit = 70.0;

        var routeSegments = new Collection<IRouteSegment>()
        {
            new PoweredRouteSegment(1000.0, new Distance(1000.0, 5.0)),
            new PoweredRouteSegment(-2000.0, new Distance(1000.0, 5.0)),
        };

        var route = new Route(routeSegments, routeSpeedLimit);

        // act
        ResultType result = route.LetsGoPassedPath(train);

        // assert
        Assert.True(result.IsSuccess, "Failure");
        Assert.True(train.Speed < 0.0);
    }
}