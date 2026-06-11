namespace AbstractFactory.Elements;

public class WebButton : IButton
{
   public string Name => "Web Button";

   public void Click()
   {
      Console.WriteLine("Web Button Clicked!");
   }

   public void Render()
   {
      Console.WriteLine("Rendering Web Button");
   }
}

public class WebTextBox : ITextBox
{
   public string Name => "Web TextBox";

   public void SetText(string text)
   {
      Console.WriteLine($"Web TextBox Text Set: {text}");
   }

   public void Render()
   {
      Console.WriteLine("Rendering Web TextBox");
   }
}
