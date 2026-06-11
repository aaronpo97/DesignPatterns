# Abstract Factory Notes

## Purpose

The Abstract Factory pattern provides an interface for creating families of related objects without specifying their concrete classes.

It is useful when a program needs to create multiple related products that must work together, such as web-style buttons and text boxes or mobile-style buttons and text boxes.

## Key Idea

A factory creates a complete product family.

Example product family:

```text
Web family:
- WebButton
- WebTextBox

Mobile family:
- MobileButton
- MobileTextBox
```

The client code does not directly create these objects. Instead, it asks a factory to create them.

## Structure

### Abstract Factory

Defines creation methods for each product type.

```text
GUIFactory
- createButton()
- createTextBox()
```

### Concrete Factories

Create products for one specific variant or family.

```text
WebGUIFactory
- creates WebButton
- creates WebTextBox

MobileGUIFactory
- creates MobileButton
- creates MobileTextBox
```

### Abstract Products

Interfaces shared by all variants of a product.

```text
Button
- render()
- click()

TextBox
- render()
- setText(text)
```

### Concrete Products

Specific implementations of the product interfaces.

```text
WebButton
MobileButton
WebTextBox
MobileTextBox
```

### Client

Works only with abstract types:

```text
GUIFactory
Button
TextBox
```

The client does not know whether it is using web or mobile products.

## How It Works

1. The application checks configuration or environment settings.
2. It chooses the correct concrete factory.
3. The factory creates related products.
4. The client uses the products through interfaces.

Example:

```text
If platform is Web:
    use WebGUIFactory

If platform is Mobile:
    use MobileGUIFactory
```

## When To Use

Use Abstract Factory when:

- Your code needs to work with different families of related products.
- You want to avoid depending on concrete classes.
- Products from one family must be compatible with each other.
- You want to make it easy to add new product variants later.
- A class has too many factory methods and product creation is becoming a separate responsibility.

## Implementation Steps

1. Identify the product types and their variants.
2. Create interfaces for each product type.
3. Create an abstract factory interface with creation methods.
4. Create concrete factories for each variant.
5. Add initialization code that chooses the correct factory.
6. Replace direct constructor calls with factory method calls.

## Benefits

- Ensures products from the same factory are compatible.
- Reduces coupling between client code and concrete classes.
- Follows the Single Responsibility Principle by moving creation logic into factories.
- Supports the Open/Closed Principle because new product families can be added without changing existing client code.

## Drawback

The pattern can make the code more complex because it introduces many new interfaces and classes.

## Related Patterns

- **Factory Method**: Often simpler; Abstract Factory may use multiple Factory Methods internally.
- **Builder**: Builds complex objects step by step, while Abstract Factory creates related objects immediately.

## Simple Summary

Abstract Factory is used to create families of related objects while keeping client code independent from the concrete classes being created.
