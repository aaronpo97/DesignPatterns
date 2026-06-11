using AbstractFactory.Elements;

namespace AbstractFactory.GuiFactory;

public class WebGUIFactory : IGUIFactory
{
   public IButton CreateButton()
   {
      return new WebButton();
   }

   public ITextBox CreateTextBox()
   {
      return new WebTextBox();
   }
}
