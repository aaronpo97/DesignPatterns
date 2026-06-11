using AbstractFactory.Elements;
using AbstractFactory.GuiFactory;

namespace AbstractFactory;

public class Client(IGUIFactory factory)
{
   readonly IButton button = factory.CreateButton();
   readonly ITextBox textBox = factory.CreateTextBox();

}
