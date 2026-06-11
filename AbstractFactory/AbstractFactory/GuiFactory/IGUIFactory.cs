using AbstractFactory.Elements;

namespace AbstractFactory.GuiFactory;

public interface IGUIFactory
{
   IButton CreateButton();
   ITextBox CreateTextBox();
}
