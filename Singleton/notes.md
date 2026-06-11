# Singleton Notes

## Purpose

The Singleton pattern ensures that a class has only one instance and provides a global access point to that instance.

In this project, `AppSettings` is the singleton. It stores shared application settings such as:

```text
AppName
IsDarkMode
FontSize
```

Any part of the program that calls `AppSettings.GetInstance()` receives the same settings object.

## Key Idea

A singleton solves two related problems:

1. It prevents more than one instance of a class from being created.
2. It gives the rest of the program one controlled access point to that instance.

This is similar to a global variable, but safer because other code cannot replace the singleton instance directly.

## Structure

### Singleton Class

The singleton class contains:

```text
private constructor
private static instance field
public static access method
```

In this project:

```text
AppSettings
- private AppSettings()
- private static AppSettings? _instance
- public static AppSettings GetInstance()
```

### Private Constructor

The constructor is private so other classes cannot create new settings objects with `new AppSettings()`.

This protects the class from direct instantiation.

### Static Instance Field

The singleton stores its one shared object in a static field:

```text
_instance
```

Because the field belongs to the class itself, it can be reused every time `GetInstance()` is called.

### Static Access Method

The `GetInstance()` method controls access to the singleton:

```text
AppSettings settings = AppSettings.GetInstance();
```

If no instance exists yet, the method creates one. After that, it returns the existing instance.

## How It Works

1. Client code calls `AppSettings.GetInstance()`.
2. If `_instance` is `null`, the class creates a new `AppSettings` object.
3. The object is stored in `_instance`.
4. Future calls return the same object.

Example:

```text
settingsOne = AppSettings.GetInstance()
settingsTwo = AppSettings.GetInstance()

settingsOne and settingsTwo refer to the same object
```

If one reference changes a property, the other reference sees that change because both point to the same instance.

## When To Use

Use Singleton when:

- A class should have exactly one shared instance.
- Many parts of the program need access to the same object.
- You need stricter control than a global variable provides.
- The object should be created only when it is first needed.

Common examples include:

- application settings
- logging services
- shared configuration
- resource managers
- database connection managers

## Implementation Steps

1. Add a private static field to store the singleton instance.
2. Make the constructor private.
3. Add a public static method that returns the singleton instance.
4. Inside the static method, create the instance only if it does not already exist.
5. Replace direct constructor calls with calls to the static access method.

## Benefits

- Guarantees that the class has only one instance.
- Provides a single access point for shared state or behavior.
- Can delay object creation until the first time it is needed.
- Keeps creation logic inside the singleton class.

## Drawbacks

- Can violate the Single Responsibility Principle because it controls both its instance creation and its main behavior.
- Can hide design problems if too many classes depend on global access to the singleton.
- Can make unit testing harder because static access methods are difficult to mock.
- Needs extra care in multithreaded programs so multiple threads do not create multiple instances at the same time.

## In This Project

`AppSettings` demonstrates Singleton by:

- hiding its constructor
- storing the single instance in `_instance`
- exposing `GetInstance()` as the only way to access the object
- sharing setting values across all references to the singleton

## Simple Summary

Singleton is used when a program needs one shared object, controlled by one class, and accessed through one static method.
