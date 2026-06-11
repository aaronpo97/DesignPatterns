namespace Singleton;

/// <summary>
/// A singleton class that holds application settings.
/// </summary>
public class AppSettings
{

   public string AppName { get; set; } = "My Application";
   public bool IsDarkMode { get; set; } = false;
   public int FontSize { get; set; } = 12;

   // A private constructor prevents instantiation from outside the class.
   private AppSettings() { }

   // A static variable to hold the single instance of the class.
   private static AppSettings? _instance;

   // A public static method to provide access to the instance.
   public static AppSettings GetInstance()
   {
      // if the instance is null, then generate it with default settings.
      _instance ??= new AppSettings();
      return _instance;
   }
}
