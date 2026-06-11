using AbstractFactory.Elements;
using AbstractFactory.GuiFactory;

namespace AbstractFactory.Tests;

public class AbstractFactoryTests
{
    /// <summary>
    /// An abstract factory creates a family of related products without the caller
    /// depending on the products' concrete classes.
    /// </summary>
    [Theory]
    [MemberData(nameof(GuiFactories))]
    public void Factory_CreatesRelatedProductsBehindAbstractTypes(
        IGUIFactory factory,
        Type expectedButtonType,
        Type expectedTextBoxType,
        string expectedButtonName,
        string expectedTextBoxName)
    {
        // Act
        var button = factory.CreateButton();
        var textBox = factory.CreateTextBox();

        // Assert
        Assert.IsAssignableFrom<IButton>(button);
        Assert.IsAssignableFrom<ITextBox>(textBox);
        Assert.IsType(expectedButtonType, button);
        Assert.IsType(expectedTextBoxType, textBox);
        Assert.Equal(expectedButtonName, button.Name);
        Assert.Equal(expectedTextBoxName, textBox.Name);
    }

    /// <summary>
    /// Client code can work with the abstract factory and product interfaces,
    /// letting the selected factory decide which concrete product family is used.
    /// </summary>
    [Theory]
    [MemberData(nameof(GuiFactoryProductNames))]
    public void ClientCode_CanUseFactoryWithoutKnowingConcreteProducts(
        IGUIFactory factory,
        string expectedButtonName,
        string expectedTextBoxName)
    {
        // Act
        var productNames = CreateGuiProductNames(factory);

        // Assert
        Assert.Equal([expectedButtonName, expectedTextBoxName], productNames);
    }

    /// <summary>
    /// The same client can swap factories to receive a different, internally
    /// consistent product family.
    /// </summary>
    [Fact]
    public void DifferentFactories_CreateDifferentProductFamilies()
    {
        // Arrange
        IGUIFactory webFactory = new WebGUIFactory();
        IGUIFactory mobileFactory = new MobileGUIFactory();

        // Act
        var webProductNames = CreateGuiProductNames(webFactory);
        var mobileProductNames = CreateGuiProductNames(mobileFactory);

        // Assert
        Assert.Equal(["Web Button", "Web TextBox"], webProductNames);
        Assert.Equal(["Mobile Button", "Mobile TextBox"], mobileProductNames);
        Assert.NotEqual(webProductNames, mobileProductNames);
    }

    public static TheoryData<IGUIFactory, Type, Type, string, string> GuiFactories =>
        new()
        {
            { new WebGUIFactory(), typeof(WebButton), typeof(WebTextBox), "Web Button", "Web TextBox" },
            { new MobileGUIFactory(), typeof(MobileButton), typeof(MobileTextBox), "Mobile Button", "Mobile TextBox" },
        };

    public static TheoryData<IGUIFactory, string, string> GuiFactoryProductNames =>
        new()
        {
            { new WebGUIFactory(), "Web Button", "Web TextBox" },
            { new MobileGUIFactory(), "Mobile Button", "Mobile TextBox" },
        };

    private static string[] CreateGuiProductNames(IGUIFactory factory)
    {
        IButton button = factory.CreateButton();
        ITextBox textBox = factory.CreateTextBox();

        return [button.Name, textBox.Name];
    }
}
