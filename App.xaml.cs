using Microsoft.Extensions.DependencyInjection;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace NoteApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}