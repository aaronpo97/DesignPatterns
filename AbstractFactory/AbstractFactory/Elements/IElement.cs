namespace AbstractFactory.Elements;

public interface IElement
{
   string Name { get; }
   void Render();
}

public interface IButton : IElement
{
   void Click();
}

public interface ITextBox : IElement
{
   void SetText(string text);
}
