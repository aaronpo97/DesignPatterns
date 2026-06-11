namespace Singleton.Tests;

public class SingletonTests : IDisposable
{
    public void Dispose()
    {
        var instance = AppSettings.GetInstance();
        instance.AppName = string.Empty;
        instance.IsDarkMode = false;
        instance.FontSize = 0;
        GC.SuppressFinalize(this);
    }
    /// <summary>
    /// A singleton must always return the same instance when accessed multiple times.
    /// </summary>
    [Fact]
    public void Singleton_ReturnsSameInstance()
    {
        // Arrange & Act
        var instance1 = AppSettings.GetInstance();
        var instance2 = AppSettings.GetInstance();

        // Assert
        Assert.Same(instance1, instance2);
    }


    /// <summary>
    /// Any changes to a singleton instance should be reflected across all references to that instance, since they all point to the same object in memory.
    /// </summary>
    [Fact]
    public void Singleton_PropertiesAreShared()
    {
        // Arrange
        var instance1 = AppSettings.GetInstance();
        instance1.AppName = "Test App";
        instance1.IsDarkMode = true;
        instance1.FontSize = 14;
        // Act
        var instance2 = AppSettings.GetInstance();
        // Assert
        Assert.Equal("Test App", instance2.AppName);
        Assert.True(instance2.IsDarkMode);
        Assert.Equal(14, instance2.FontSize);
    }



    /// <summary>
    /// A singleton class should not allow direct instantiation from outside the class, ensuring that only one instance can exist.
    /// </summary>
    [Fact]
    public void Singleton_CannotBeDirectlyInstantiated()
    {
        var constructors = typeof(AppSettings)
            .GetConstructors(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        Assert.Empty(constructors);
    }


    /// <summary>
    /// Even if you try to change the properties of a singleton instance, it should still be the same instance, and any changes will affect all references to that instance.
    /// </summary>

    [Fact]
    public void Singleton_MutationDoesNotChangeInstance()
    {
        var before = AppSettings.GetInstance();
        before.AppName = "Changed";

        var after = AppSettings.GetInstance();

        Assert.Same(before, after);
    }
}
