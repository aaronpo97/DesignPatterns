using AbstractFactory.Elements;

namespace AbstractFactory.GuiFactory;

public class MobileGUIFactory : IGUIFactory
{
   public IButton CreateButton()
   {
      return new MobileButton();
   }

   public ITextBox CreateTextBox()
   {
      return new MobileTextBox();
   }
}
