# Factory Method Notes

## Purpose

The Factory Method pattern provides an interface for creating objects in a base class, while allowing subclasses to decide which concrete class should be created.

In this project, the example is a logistics application. The client asks a logistics factory to plan a delivery, but it does not need to know whether the delivery uses a truck or a ship.

## Key Idea

Factory Method replaces direct constructor calls with a method whose job is to create the product.

Instead of client code doing this:

```text
new Truck()
```

it asks a creator to create a transport:

```text
logisticsFactory.CreateTransport()
```

The returned object still gets created with `new`, but that construction is hidden inside the factory method.

## Problem

Imagine a logistics management application that originally supports only truck transportation.

At first, much of the code may directly depend on `Truck`.

Later, sea transportation needs to be added. If the application is tightly coupled to `Truck`, adding `Ship` requires changes throughout the codebase.

As more transportation types are added, the code can become filled with conditionals that switch behavior based on the concrete transport class.

## Solution

Factory Method moves product creation into a method declared by a creator class.

Subclasses override that method to return different products:

```text
RoadLogistics creates Truck
SeaLogistics creates Ship
```

The client code works with the shared product interface:

```text
ITransport
```

This means the client can use any transport object as long as it supports the same behavior.

## Structure

### Product

The product declares the common interface for all objects that can be created by the factory method.

In this project:

```text
ITransport
- Deliver()
```

### Concrete Products

Concrete products implement the product interface.

In this project:

```text
Truck
- Deliver by land

Ship
- Deliver by sea
```

### Creator

The creator declares the factory method. The factory method returns the product interface, not a concrete product type.

In this project:

```text
LogisticsFactory
- PlanDelivery()
- CreateTransport()
```

`PlanDelivery()` contains business logic that works with `ITransport`.

`CreateTransport()` is the factory method.

### Concrete Creators

Concrete creators override the factory method to return a specific concrete product.

In this project:

```text
RoadLogistics
- creates Truck

SeaLogistics
- creates Ship
```

## How It Works

1. Client code chooses a concrete logistics factory.
2. The client calls `PlanDelivery()`.
3. `PlanDelivery()` calls `CreateTransport()`.
4. The concrete factory creates the correct transport object.
5. The client receives delivery behavior without depending on `Truck` or `Ship` directly.

Example:

```text
RoadLogistics.PlanDelivery()
    CreateTransport()
    Truck.Deliver()

SeaLogistics.PlanDelivery()
    CreateTransport()
    Ship.Deliver()
```

## Why Products Need A Shared Interface

Factory Method works best when all products follow the same interface.

In this example, both `Truck` and `Ship` implement `ITransport`, so the creator can treat them the same way:

```text
ITransport transport = CreateTransport()
transport.Deliver()
```

The creator does not need to know which concrete transport was returned.

## When To Use

Use Factory Method when:

- A class cannot know ahead of time which concrete product it should create.
- Subclasses should be able to choose the product type.
- Client code should depend on interfaces instead of concrete classes.
- You want to remove repeated `new` calls from client code.
- You want to avoid large conditional blocks that choose between concrete product classes.

## Implementation Steps

1. Identify the common behavior shared by products.
2. Create a product interface.
3. Create concrete product classes that implement the interface.
4. Create an abstract creator with a factory method.
5. Make the factory method return the product interface.
6. Create concrete creators that override the factory method.
7. Move client code to use the creator and product interface instead of concrete products.

## Benefits

- Reduces coupling between client code and concrete classes.
- Keeps product creation in one focused place.
- Lets subclasses choose which product to create.
- Supports the Open/Closed Principle because new creators and products can be added without changing existing client code.
- Keeps creator business logic reusable across product types.

## Drawbacks

- Adds extra classes and interfaces.
- Can feel too heavy if the program only ever creates one simple object.
- Requires products to share a useful common interface.

## In This Project

The Factory Method pattern is represented by:

```text
ITransport
Truck
Ship
LogisticsFactory
RoadLogistics
SeaLogistics
```

`LogisticsFactory` contains the shared delivery-planning logic and declares `CreateTransport()`.

`RoadLogistics` returns a `Truck`.

`SeaLogistics` returns a `Ship`.

The tests show that client code can use `LogisticsFactory` and `ITransport` without knowing which concrete transport class is created.

## Related Patterns

- **Abstract Factory**: Creates families of related products. It often contains several Factory Methods.
- **Template Method**: Similar structure, but focuses on overriding steps of an algorithm instead of object creation.
- **Builder**: Builds complex objects step by step, while Factory Method usually creates one product through one method.

## Simple Summary

Factory Method is used when a base class defines how product creation is requested, but subclasses decide which concrete product to create.
