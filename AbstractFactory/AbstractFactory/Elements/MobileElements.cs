namespace AbstractFactory.Elements;

public class MobileButton : IButton
{
   public string Name => "Mobile Button";

   public void Click()
   {
      Console.WriteLine("Mobile Button Clicked!");
   }

   public void Render()
   {
      Console.WriteLine("Rendering Mobile Button");
   }
}

public class MobileTextBox : ITextBox
{
   public string Name => "Mobile TextBox";

   public void SetText(string text)
   {
      Console.WriteLine($"Mobile TextBox Text Set: {text}");
   }

   public void Render()
   {
      Console.WriteLine("Rendering Mobile TextBox with text: {Name}");
   }
}
